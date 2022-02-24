using Hashboile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hashboile.Contracts
{
    interface ISimulator
    {
        long Simulate(Output output, MetricDirective metric);
    }
}
