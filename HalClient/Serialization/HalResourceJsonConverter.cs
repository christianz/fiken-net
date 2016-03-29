using System;
using Fiken.Net.HalClient.Models;
using Newtonsoft.Json;

namespace Fiken.Net.HalClient.Serialization
{
    internal sealed class HalResourceJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existing, JsonSerializer serializer)
            => HalResourceJsonReader.ReadResource(reader, serializer);

        public override bool CanConvert(Type objectType) => typeof (IResource).IsAssignableFrom(objectType);
    }
}