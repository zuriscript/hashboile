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
         
            //writer.WriteInitialToken(output.Ingredients.Count);
            //foreach(var ingredient in output.Ingredients)
            //{
            //    writer.WriteToken(ingredient);
            //}
        }
    }
}
