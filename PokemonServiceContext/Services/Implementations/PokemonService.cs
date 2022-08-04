using PokemonDomain;
using PokemonDomain.Model;
using PokemonDomain.Model.Detail;
using PokemonMVVM.Core.Model;
using PokemonServiceContext.Rest;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonServiceContext.Services
{
    public class PokemonService : IPokemonService
    {
        public PokemonService()
        {
            
        }


        public Task<PagedResult<PokemonGeneration>> GetPokemonAsync(IRestClient restClient, string url = null)
        {
           
            return string.IsNullOrEmpty(url)
                        ? restClient.MakeApiCall<PagedResult<PokemonGeneration>>($"{Constants.BaseUrl}/pokemon/", HttpMethod.Get)
                        : restClient.MakeApiCall<PagedResult<PokemonGeneration>>(url, HttpMethod.Get);
        }

        public Task<PagedResult<PokemonGeneration>> GetPokemonTypeAsync(IRestClient restClient, string url = null)
        {
            return string.IsNullOrEmpty(url)
                        ? restClient.MakeApiCall<PagedResult<PokemonGeneration>>($"{Constants.BaseUrl}/type/", HttpMethod.Get)
                        : restClient.MakeApiCall<PagedResult<PokemonGeneration>>(url, HttpMethod.Get);
        }

        public Task<PokemonTypeRoot> GetPokemonTypeIdAsync(IRestClient restClient, string url = null)
        {
            return string.IsNullOrEmpty(url)
                       ? restClient.MakeApiCall<PokemonTypeRoot>($"{Constants.BaseUrl}/type/", HttpMethod.Get)
                       : restClient.MakeApiCall<PokemonTypeRoot>(url, HttpMethod.Get);
        }

        public Task<PokemonDetail> GetPokemonDetailAsync(IRestClient restClient, string url)
        {
            return string.IsNullOrEmpty(url)
                         ? restClient.MakeApiCall<PokemonDetail>($"{Constants.BaseUrl}/pokemon/", HttpMethod.Get)
                         : restClient.MakeApiCall<PokemonDetail>(url, HttpMethod.Get);
        }
    }
}
