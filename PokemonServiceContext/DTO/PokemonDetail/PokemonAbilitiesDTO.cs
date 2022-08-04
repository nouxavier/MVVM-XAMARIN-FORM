using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonDomain.Model.PokemonDetail
{
    public class PokemonAbilitiesDTO
    {
        public int Name { get; set; }
        public int Slot { get; set; }
        public PokemonAbilityDTO Ability { get; set; }
    }
}
