using PokemonDomain.Logs;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonServiceContext.Rest
{
    public interface IRestClient
    {
        Task<TResult> MakeApiCall<TResult>(string url, HttpMethod method, object data = null)
                        where TResult : class;
    }
}
