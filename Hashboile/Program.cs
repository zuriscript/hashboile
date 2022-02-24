using Hashboile.Models;
using Hashboile.Utility.Execution;

var runner = HashBoileRunner.Create(inputFileTokenDelimitier: " ");

runner.Run(
    "a_an_example.in.txt", 
    "a_an_example.out.txt", 
    MetricDirective.General);

runner.RunWithSimulation(
    "b_basic.in.txt", 
    "b_basic.out.txt", 
    MetricDirective.General, 
    1);

runner.RunWithSimulation(
    "c_coarse.in.txt",
    "c_coarse.out.txt",
    MetricDirective.General,
    4);

runner.RunWithSimulation(
    "d_difficult.in.txt",
    "d_difficult.out.txt",
    MetricDirective.General,
    20);

runner.Run(
    "e_elaborate.in.txt",
    "e_elaborate.out.txt",
    MetricDirective.General);

