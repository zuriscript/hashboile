using Hashboile.Contracts;
using Hashboile.Models;
using Hashboile.Utility.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashboile.Implementations
{
    class InputParser : IInputParser
    {
        public Input Parse(FileReader reader)
        {
            var input = new Input();
            input.NumberOfContributor = reader.Next<int>();
            input.NumberOfProjects = reader.Next<int>();

            for (int i = 0; i < input.NumberOfContributor; i++)
            {
                var contributor = new InputContributor();
                contributor.Name = reader.Next<string>();
                contributor.NumberOfSkills = reader.Next<int>();

                for(int j = 0; j < contributor.NumberOfSkills; j++)
                {
                    var skill = new InputSkill();
                    skill.Name = reader.Next<string>();
                    skill.Level = reader.Next<int>();
                    contributor.Skills.Add(skill);
                }

                input.Contributors.Add(contributor);
            }

            for(int i = 0; i < input.NumberOfProjects; i++)
            {
                var project = new InputProject();
                project.Name = reader.Next<string>();
                project.NumberOfDaysToComplete = reader.Next<int>();
                project.ScoreAwardedForCompletion = reader.Next<int>();
                project.CompleteBestBeforeDay = reader.Next<int>();
                project.NumberOfRoles = reader.Next<int>();

                for(int j = 0; j < project.NumberOfRoles; j++)
                {
                    var role = new InputRole();
                    role.Name = reader.Next<string>();
                    role.RequiredLevel = reader.Next<int>();
                    project.Roles.Add(role);
                }

                input.Projects.Add(project);
            }

            return input;
        }
    }
}
