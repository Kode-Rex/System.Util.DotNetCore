using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StoneAge.System.Utils.JsonUtils;

namespace StoneAge.System.Utils.Json
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerSettings CamelcaseJsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        private static readonly JsonSerializerSettings LowercaseJsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new LowercaseContractResolver()
        };

        public static object FormatStringForJson(this string input)
        {
            return JsonConvert.DeserializeObject<object>(input);
        }

        public static string Serialize(this object input)
        {
            return JsonConvert.SerializeObject(input, CamelcaseJsonSerializerSettings);
        }

        public static string Serialize_With_LowerCase_Settings(this object input)
        {
            return JsonConvert.SerializeObject(input, LowercaseJsonSerializerSettings);
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
                    Model = parsedModel
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

        private class LowercaseContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return propertyName.ToLower();
            }
        }
    }
}
