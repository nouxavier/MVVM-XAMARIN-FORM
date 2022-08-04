using Newtonsoft.Json;
using System;


namespace PokemonDomain.Model
{
    public class PokemonGeneration: ResultPokemon
    {
       
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonConstructor]
        public PokemonGeneration(string name, Uri url)
        {
            Name = name;
            Url = url;
            var old = url.ToString()?.Split('/');
            UrlImage = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/" + old[6] + ".png";
        }

    }
}
