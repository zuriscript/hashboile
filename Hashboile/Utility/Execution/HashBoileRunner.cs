using Hashboile.Contracts;
using Hashboile.Implementations;
using Hashboile.Models;
using Hashboile.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashboile.Utility.Execution
{
    class HashBoileRunner
    {
        private readonly IInputParser _inputParser;
        private readonly IOutputSerializer _outputSerializer;
        private readonly ISimulator _simulator;
        private readonly ISolver _solver;
        private readonly string _delimitier;

        private HashBoileRunner(
            IInputParser inputParser,
            IOutputSerializer outputSerializer,
            ISimulator simulator,
            ISolver solver,
            string delimitier)
        {
            _inputParser = inputParser;
            _outputSerializer = outputSerializer;
            _simulator = simulator;
            _solver = solver;
            _delimitier = delimitier;
        }

        public static HashBoileRunner Create(string inputFileTokenDelimitier)
        {
            return new HashBoileRunner(
                new InputParser(),
                new OutputSerializer(),
                new Simulator(),
                new Solver(),
                inputFileTokenDelimitier);
        }


        public void Run(string inputFile, string outputFile, MetricDirective directive)
            => RunWithSimulation(inputFile, outputFile, directive, -1);

        public void RunWithSimulation(string inputFile, string outputFile, MetricDirective directive, int simulationCount)
        {
            SimpleLogger.BreakWithSymbols();
            SimpleLogger.LogLine($"HashBoile Run for {inputFile}", ConsoleColor.Blue);
            SimpleLogger.BreakWithSymbols();

            var sw = Stopwatch.StartNew();

            var input = readInput(inputFile);
            var output = simulationCount > 0 ? 
                RunAndSimulateAndTakeBest(input, directive, simulationCount) :
                solve(input, directive);
            writeOutput(outputFile, output);

            SimpleLogger.LogLine($"Finnished in {sw.StopAndReturnEllapsedSeconds()} seconds", ConsoleColor.Green);
            SimpleLogger.BreakWithSymbols();
        }

        private Input readInput(string inputFile)
        {
            var sw = Stopwatch.StartNew();
            using var reader = FileReader.ReadFrom(inputFile, _delimitier);
            var input = _inputParser.Parse(reader);
            SimpleLogger.LogLine($"Input {inputFile} parsed in {sw.StopAndReturnEllapsedSeconds()} seconds");
            return input;
        }

        private void writeOutput(string outputFile, Output output)
        {
            var sw = Stopwatch.StartNew();
            using var writer = FileWriter.WriteTo(outputFile, _delimitier);
            _outputSerializer.Serialize(writer, output);
            SimpleLogger.LogLine($"Output written to {outputFile} in {sw.StopAndReturnEllapsedSeconds()} seconds");
        }

        private Output solve(Input input, MetricDirective directive, string prefix = "", bool silent = false)
        {
            var sw = Stopwatch.StartNew();
            var solution = _solver.Solve(input, directive);
            if(!silent)
            {
                SimpleLogger.LogLine($"{prefix}Solved with {directive} metric in {sw.StopAndReturnEllapsedSeconds()} seconds");
            }
            return solution;
        }

        private long simulate(Input input, Output output, MetricDirective directive, string prefix = "", bool silent = false)
        {
            var sw = Stopwatch.StartNew();
            var score = _simulator.Simulate(input, output, directive);
            if(!silent)
            {
                SimpleLogger.LogLine($"{prefix}Simulated score {score} with {directive} metric in {sw.StopAndReturnEllapsedSeconds()} seconds");
            }
            return score;
        }

        private Output RunAndSimulateAndTakeBest(Input input, MetricDirective directive, int n)
        {
            var sw = Stopwatch.StartNew();

            List<(Output,long)> outputsWithScore = new();
            for(int i = 1; i<=n; i++)
            {
                var output = solve(input, directive, $"[{i}/{n}] ", n > 8);
                var score = simulate(input, output, directive, $"[{i}/{n}] ", n > 8);
                outputsWithScore.Add((output, score));
            }

            var result = outputsWithScore
                .OrderByDescending(x => x.Item2)
                .First();
            
            var minima = outputsWithScore.Min(x => x.Item2);
            var average = outputsWithScore.Sum(x => x.Item2) / n;
            var median = outputsWithScore
                .Select(x => x.Item2)
                .OrderBy(x => x)
                .Skip(n / 2)
                .First();

            SimpleLogger.LogLine($"Finnished {n} runs with simulation in {sw.StopAndReturnEllapsedSeconds()} seconds", ConsoleColor.Yellow);
            SimpleLogger.LogToken($"  Maxima:  "); SimpleLogger.LogLine(result.Item2.ToString(), ConsoleColor.Cyan);
            SimpleLogger.LogToken($"  Minima:  "); SimpleLogger.LogLine(minima.ToString(), ConsoleColor.Cyan);
            SimpleLogger.LogToken($"  Median:  "); SimpleLogger.LogLine(median.ToString(), ConsoleColor.Cyan);
            SimpleLogger.LogToken($"  Average: "); SimpleLogger.LogLine(average.ToString(), ConsoleColor.Cyan);

            return result.Item1;
        }
    }
}
