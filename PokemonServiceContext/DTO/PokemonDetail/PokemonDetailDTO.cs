using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonDomain.Model.PokemonDetail
{
    public class PokemonDetailDTO
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int BaseExperience { get; set; }
        public int Height { get; set; }
        public int IsDefault { get; set; }
        public int Order { get; set; }
        public int Weight { get; set; }
        
    }
}
