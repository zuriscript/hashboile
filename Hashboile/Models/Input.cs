using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hashboile.Models
{
    class Input
    {
        public int NumberOfContributor { get; set; }
        public int NumberOfProjects { get; set; }
        public HashSet<InputContributor> Contributors { get; set; } = new();
        public HashSet<InputProject> Projects { get; set; } = new();


        public List<InputContributor> GetSeniorsWithRole(InputRole role)
        {
            return Contributors
                .Where(c => c.CanBeSeniorForRole(role))
                .ToList();
        }
    }
    
}
