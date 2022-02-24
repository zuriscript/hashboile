using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashboile.Utility.Extensions
{
    static class StopwatchExtension
    {
        public static double StopAndReturnEllapsedSeconds(this Stopwatch stopwatch)
        {
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds / 1000.0;
        }
    }
}
