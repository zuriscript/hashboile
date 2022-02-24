using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashboile.Models
{
    class InputContributor
    {
        public string Name { get; set; }
        public int NumberOfSkills { get; set; }
        public List<InputSkill> Skills { get; set; }
    }
}
