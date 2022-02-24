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
    class OutputSerializer : IOutputSerializer
    {
        public void Serialize(FileWriter writer, Output output)
        {
            var projection = output.GetSolutionSet();
            writer.WriteInitialToken(projection.Count);
            writer.WriteLineBreak();
            foreach(var project in projection)
            {                
                writer.WriteInitialToken(project.Name);
                writer.WriteLineBreak();
                writer.WriteInitialToken(string.Join(' ', project.NameOfContributors));
                writer.WriteLineBreak();
            }
        }
    }
}
