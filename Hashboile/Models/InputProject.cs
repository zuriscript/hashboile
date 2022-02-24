using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashboile.Models
{
    class InputProject
    {
        public string Name { get; set; }
        public int NumberOfDaysToComplete { get; set; }
        public int ScoreAwardedForCompletion { get; set; }
        public int CompleteBestBeforeDay { get; set; }
        public int NumberOfRoles { get; set; }
        public List<InputRole> Roles { get; set; }

    }
}
