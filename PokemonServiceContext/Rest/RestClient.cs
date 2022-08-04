using Newtonsoft.Json;
using PokemonDomain.Logs;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace PokemonServiceContext.Rest
{
    public class RestClient : IRestClient
    {
        private readonly ILog log;

      
        public async Task<TResult> MakeApiCall<TResult>(string url, HttpMethod method, object data = null) where TResult : class
        {
            url = url.Replace("http://", "https://");

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage { RequestUri = new Uri(url), Method = method })
                {
                    if (method != HttpMethod.Get)
                    {
                        string json = JsonConvert.SerializeObject(data);
                        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                    }

                    HttpResponseMessage response = new HttpResponseMessage();
                    try
                    {
                        response = await httpClient.SendAsync(request).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        log.AppCrash(ex, "MakeApiCall failed", "MakeApiCall failed");
                    }

                    var stringSerialized = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<TResult>(stringSerialized);
                }
            }
        }
    }
}
