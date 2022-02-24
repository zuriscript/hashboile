using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashboile.Models
{
    class OutputProject
    {
        public string Name { get; set; }
        public List<string> NameOfContributors { get; set; } = new();
    }
}
