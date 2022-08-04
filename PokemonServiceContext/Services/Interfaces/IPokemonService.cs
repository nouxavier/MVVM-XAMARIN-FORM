using PokemonDomain;
using PokemonDomain.Model;
using PokemonDomain.Model.Detail;
using PokemonMVVM.Core.Model;
using PokemonServiceContext.Rest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonServiceContext.Services
{
    public interface IPokemonService
    {
        Task<PagedResult<PokemonGeneration>> GetPokemonAsync(IRestClient restClient, string url = null);
        Task<PagedResult<PokemonGeneration>> GetPokemonTypeAsync(IRestClient restClient, string url = null);
        Task<PokemonTypeRoot> GetPokemonTypeIdAsync(IRestClient restClient, string url = null);
        Task<PokemonDetail> GetPokemonDetailAsync(IRestClient restClient, string url = null);

    }
}
