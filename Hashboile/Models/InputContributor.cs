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
        public HashSet<InputSkill> Skills { get; set; } = new();

        public bool CanBeSeniorForRole(InputRole role)
        {
            return Skills
                .Any(skill => skill.Name == role.Name && skill.Level >= role.RequiredLevel);
        }

        public bool CanBeJuniorForRole(InputRole role)
        {
            return Skills
                .Any(skill => skill.Name == role.Name && skill.Level >= role.RequiredLevel -1);
        }
    }
}
