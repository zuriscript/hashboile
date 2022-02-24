using System;
using System.Collections.Generic;
using System.Text;

namespace Hashboile.Models
{
    class Input
    {
        public int PotentialClientsCount { get; set; }
        public List<Client> Clients { get; set; } = new List<Client>();

    }
    
    class Client
    {
        public List<string> LikedIngredients { get; set; } = new List<string>();
        public List<string> DisLikedIngredients { get; set; } = new List<string>();
    }
}
