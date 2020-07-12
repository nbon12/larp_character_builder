using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Core.Extensions
{
    public static class JsonObjectExtensions
    {
        private static readonly JsonSerializerSettings DefaultJsonSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented,
            DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
            TypeNameHandling = TypeNameHandling.None
        };

        private static string Serialize(object o, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(o, DefaultJsonSettings);
        }

        public static string ToJSON(this object o)
        {
            return Serialize(o, DefaultJsonSettings);
        }
        public static string ToJSON(this object o, JsonSerializerSettings settings)
        {
            return Serialize(o, settings);
        }

        public static T FromJSON<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json, DefaultJsonSettings);
        }

        public static T FromJSON<T>(this string json, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(json, settings);
        }


        public static StringContent ToJsonStringContent(this object obj)
        {
            var jsonContent = new StringContent(obj?.ToJSON());
            jsonContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return jsonContent;
        }
    }
}