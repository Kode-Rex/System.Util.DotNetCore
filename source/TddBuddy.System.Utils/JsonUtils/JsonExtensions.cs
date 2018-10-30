using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TddBuddy.System.Utils.JsonUtils
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerSettings CamelcaseJsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public static object FormatStringForJson(this string input)
        {
            return JsonConvert.DeserializeObject<object>(input);
        }

        public static string Serialize(this object input)
        {
            return JsonConvert.SerializeObject(input, CamelcaseJsonSerializerSettings);
        }

        public static T Deserialize<T>(this string model)
        {
            return JsonConvert.DeserializeObject<T>(model, CamelcaseJsonSerializerSettings);
        }

        public static DeserializationResult<T> TryDeserialize<T>(this string model)
        {
            try
            {
                var parsedModel = ParseModelExact<T>(model);
                return new DeserializationResult<T>
                {
                    IsValid = true,
                    ParsedModel = parsedModel
                };
            }
            catch (JsonException e)
            {
                var result = new DeserializationResult<T> { IsValid = false };
                result.Errors.Add(e.Message);
                return result;
            }
        }

        private static T ParseModelExact<T>(string model)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Error,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.DeserializeObject<T>(model, jsonSerializerSettings);
        }
    }
}
