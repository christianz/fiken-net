using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Fiken.Net.Api;

namespace Fiken.Net
{
    public sealed class FikenSession : HalClient.HalClient
    {
        private const string BaseUrl = "https://fiken.no/api/v1/";
        private const string CompaniesRel = "companies";
        public string Name { get; private set; }
        public Guid? RequestId { get; private set; }

        public FikenSession(string username, string password, Guid? requestId = null) : base(GetHttpClient(username, password, requestId))
        {
            if (requestId.HasValue)
            {
                RequestId = requestId.Value;
            }
        }

        private static FikenJsonClient GetHttpClient(string username, string password, Guid? requestId = null)
        {
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));

            var http = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl),
                DefaultRequestHeaders =
                {
                    Authorization = AuthenticationHeaderValue.Parse("Basic " + credentials)
                }
            };

            if (requestId.HasValue)
            {
                http.DefaultRequestHeaders.Add("X-Request-ID", requestId.Value.ToString("N"));
            }

            return new FikenJsonClient(http, new HalJsonMediaTypeFormatter());
        }

        public new FikenSession Root()
        {
            var actualRoot = (FikenSession)base.Root(BaseUrl);
            
            return actualRoot.Get(CompaniesRel).Get(CompaniesRel);
        }

        public new FikenSession Root(string slug)
        {
            var actualRoot = (FikenSession)base.Root(BaseUrl);

            return actualRoot.Get(CompaniesRel).Get(CompaniesRel, new { slug });
        }

        public new FikenSession Get(string rel)
        {
            return Get(rel, null);
        }

        public new FikenSession Get(string rel, object parameters)
        {
            var queryUrl = BaseUrl + "rel/" + rel;

            return (FikenSession)base.Get(queryUrl, parameters);
        }

        public new FikenSession Post(string rel, object value)
        {
            var queryUrl = BaseUrl + "rel/" + rel;

            return (FikenSession)base.Post(queryUrl, value);
        }
    }
}
