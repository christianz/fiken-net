using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HoneyBear.HalClient.Http;

namespace Fiken.Net.Api
{
    internal class FikenJsonClient : IJsonHttpClient
    {
        private readonly MediaTypeFormatter _mediaTypeFormatter;

        public FikenJsonClient(HttpClient client, MediaTypeFormatter mediaTypeFormatter)
        {
            HttpClient = client;
            _mediaTypeFormatter = mediaTypeFormatter;

            AcceptJson();
            AcceptHalJson();
        }

        public HttpClient HttpClient { get; }

        public Task<HttpResponseMessage> GetAsync(string uri)
            => HttpClient.GetAsync(uri);

        public Task<HttpResponseMessage> PostAsync<T>(string uri, T value)
            => HttpClient.PostAsync(uri, value, _mediaTypeFormatter);

        public Task<HttpResponseMessage> PutAsync<T>(string uri, T value)
            => HttpClient.PutAsync(uri, value, _mediaTypeFormatter);

        public Task<HttpResponseMessage> DeleteAsync(string uri)
            => HttpClient.DeleteAsync(uri);

        private void AcceptJson()
        {
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void AcceptHalJson()
        {
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
        }
    }
}
