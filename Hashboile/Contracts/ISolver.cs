using Hashboile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hashboile.Contracts
{
    interface ISolver
    {
        Output Solve(Input input, MetricDirective metric);
    }
}
