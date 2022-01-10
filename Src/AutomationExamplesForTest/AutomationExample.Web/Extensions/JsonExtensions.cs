using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AutomationExample.Web.Extensions
{
    public static class JsonExtensions
    {
        /// <summary>
        ///     Async Parse an object from a string using the object Template return type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static async Task<T> FromJsonAsync<T>(this string json)
        {
            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }

        /// <summary>
        ///     Parse an object from a string using the object Template return type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T FromJson<T>(this string json)
        {
            return FromJsonAsync<T>(json).GetAwaiter().GetResult();
        }

        /// <summary>
        ///     Async Convert an object into a json string object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static async Task<string> ToJsonAsync(this object value)
        {
            return await Task.Run(() => JsonConvert.SerializeObject(value));
        }

        /// <summary>
        ///     Convert an object into a json string object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToJson(this object value)
        {
            return ToJsonAsync(value).GetAwaiter().GetResult();
        }

        /// <summary>
        ///     Async Convert a json string to an object of type that is unknown
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        public static async Task<JObject> FromJsonToJObjectAsync(this string json)
        {
            if (string.IsNullOrEmpty(json)) return null;

            return await Task.Run(() => JObject.Parse(json));
        }

        /// <summary>
        ///     Convert a json string to an object of type that is unknown
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static JObject FromJsonToJObject(this string json)
        {
            return FromJsonToJObjectAsync(json).GetAwaiter().GetResult();
        }

        /// <summary>
        ///     Async Convert a json array string to an object of type that is unknown
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        public static async Task<JArray> FromJsonToJArrayAsync(this string json)
        {
            if (string.IsNullOrEmpty(json)) return null;

            return await Task.Run(() => JArray.Parse(json));
        }

        /// <summary>
        ///     Convert a json array string to an object of type that is unknown
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static JArray FromJsonToJArray(this string json)
        {
            return FromJsonToJArrayAsync(json).GetAwaiter().GetResult();
        }
    }
}