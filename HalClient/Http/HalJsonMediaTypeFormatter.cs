using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace Fiken.Net.HalClient.Http
{
    internal class HalJsonMediaTypeFormatter : JsonMediaTypeFormatter
    {
        public HalJsonMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/hal+json"));
        }
    }
}