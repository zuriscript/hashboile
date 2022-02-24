using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashboile.Utility.Execution
{
    static class SimpleLogger
    {
        public static void LogLine(string message, ConsoleColor? color = default)
            => RunInColorContex(color, () => Console.WriteLine(message));

        public static void LogToken(string token, ConsoleColor? color = default)
            => RunInColorContex(color, () => Console.Write(token));

        public static void Break()
            => Console.WriteLine();

        public static void BreakWithSymbols()
            => Console.WriteLine("-------------------------------------------------------------");


        private static void RunInColorContex(ConsoleColor? color, Action action)
        {
            if(color.HasValue)
            {
                var temp = Console.ForegroundColor;
                Console.ForegroundColor = color.Value;
                action();
                Console.ForegroundColor = temp;
            }
            else
            {
                action();
            }   
        }

    }
}
