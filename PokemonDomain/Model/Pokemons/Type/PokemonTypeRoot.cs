using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonDomain.Model
{
    public class PokemonTypeRoot
    {

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pokemon")]
        public Pokemon[] Pokemon { get; set; }
    }
}
