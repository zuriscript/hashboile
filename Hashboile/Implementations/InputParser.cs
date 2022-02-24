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
            input.PotentialClientsCount = reader.Next<int>();
            for(int i = 0; i< input.PotentialClientsCount; i++)
            {
                var client = new Client();

                var likeCount = reader.Next<int>();
                for(int j = 0; j <likeCount; j++)
                    client.LikedIngredients.Add(reader.Next<string>());

                var dislikedCount = reader.Next<int>();
                for (int j = 0; j < dislikedCount; j++)
                    client.DisLikedIngredients.Add(reader.Next<string>());

                input.Clients.Add(client);
            }

            return input;
        }
    }
}
