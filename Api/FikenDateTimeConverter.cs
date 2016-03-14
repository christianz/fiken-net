using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Fiken.Net.Api
{
    internal class FikenDateTimeConverter : DateTimeConverterBase
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dtVal = (DateTime)value;

            writer.WriteValue(dtVal.ToString("yyyy-MM-dd"));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DateTime.ParseExact(existingValue.ToString(), "yyyy-MM-dd", null);
        }
    }
}
