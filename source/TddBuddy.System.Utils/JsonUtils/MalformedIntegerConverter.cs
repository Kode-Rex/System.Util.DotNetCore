using System;
using Newtonsoft.Json;

namespace TddBuddy.System.Utils.JsonUtils
{
    public class MalformedIntegerJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            int result;
            var canidateValue = reader.Value.ToString();
            return !int.TryParse(canidateValue, out result) ? 0 : result;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}