using Hashboile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hashboile.Contracts
{
    interface ISimulator
    {
        long Simulate(Input input, Output output, MetricDirective metric);
    }
}
