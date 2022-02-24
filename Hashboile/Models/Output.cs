using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hashboile.Models
{
    class Output
    {
        public List<OutputProject> Projects { get; set; } = new();

        public List<OutputProject> GetSolutionSet()
        {
            return Projects;
        }

    }
}
