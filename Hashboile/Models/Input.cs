using System;
using System.Collections.Generic;
using System.Text;

namespace Hashboile.Models
{
    class Input
    {
        public int NumberOfContributor { get; set; }
        public int NumberOfProjects { get; set; }
        public List<InputContributor> Contributors { get; set; }
        public List<InputProject> Projects { get; set; }
    }
    
}
