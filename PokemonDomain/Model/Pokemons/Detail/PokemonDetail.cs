using Newtonsoft.Json;
using PokemonDomain.Model.Pokemons.Type;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonDomain.Model.Detail
{
    public partial class PokemonDetail
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("types")]
        public PokemonType[] Types { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }
    }
}
