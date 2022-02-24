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
            return new Output
            {
                Ingredients = input.Clients.SelectMany(x => x.LikedIngredients).ToList()
            };
        }
    }
}
