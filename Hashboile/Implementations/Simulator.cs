using Hashboile.Contracts;
using Hashboile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashboile.Implementations
{
    class Simulator : ISimulator
    {
        public long Simulate(Output output, MetricDirective metric)
        {
            return DateTime.Now.Ticks / 100000;
        }
    }
}
