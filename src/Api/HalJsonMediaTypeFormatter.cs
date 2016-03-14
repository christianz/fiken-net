using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Fiken.Net.Api
{
    /// <summary>
    /// 
    /// </summary>
    internal class HalJsonMediaTypeFormatter : JsonMediaTypeFormatter
    {
        /// <summary>
        /// 
        /// </summary>
        public HalJsonMediaTypeFormatter()
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new LowerCamelCaseContractResolver();
            serializerSettings.NullValueHandling = NullValueHandling.Ignore;
            serializerSettings.Converters.Add(new FikenDateTimeConverter());

            SerializerSettings = serializerSettings;

            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/hal+json"));
        }
    }

}
