using Newtonsoft.Json;

namespace PokemonDomain.Model.Pokemons.Type
{
    public class PokemonType
    {
        [JsonProperty("type")]
        public PokemonGeneration PokemonGeneration { get; set; }

        [JsonProperty("slot")]
        public long Slot { get; set; }
    }
}
