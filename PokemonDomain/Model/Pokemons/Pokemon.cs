using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonDomain.Model
{
    public class Pokemon
    {
        [JsonProperty("pokemon")]
        public PokemonGeneration PokemonGeneration { get; set; }

        [JsonProperty("slot")]
        public long Slot { get; set; }
    }
}
