using Hashboile.Contracts;
using Hashboile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashboile.Implementations
{
    class Solver : ISolver
    {
        public Output Solve(Input input, MetricDirective metric)
        {
            var output = new Output();


            foreach(var project in input.Projects)
            {
                var outputProject = new OutputProject
                {
                    Name = project.Name
                };

                foreach(var role in project.Roles)
                {
                    var contributor = input
                        .GetSeniorsWithRole(role)
                        .Where(x => !outputProject.NameOfContributors.Contains(x.Name))
                        .FirstOrDefault();

                    if(contributor != default)
                    {
                        outputProject.NameOfContributors.Add(contributor.Name);
                    }   
                }

                if(outputProject.NameOfContributors.Count == project.Roles.Count)
                {
                    output.Projects.Add(outputProject);
                }
            }

            return output;
        }
    }
}
