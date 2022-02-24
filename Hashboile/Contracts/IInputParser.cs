using Hashboile.Models;
using Hashboile.Utility.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashboile.Contracts
{
    interface IInputParser
    {
        Input Parse(FileReader reader);
    }
}
