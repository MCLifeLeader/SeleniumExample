using System.Threading.Tasks;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AutomationExample.Tests.Extensions
{
    /// <summary>
    ///     Json object manipulation extension methods
    /// </summary>
    public static class JsonExtensions
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(JsonExtensions));

        /// <summary>
        ///     Async Parse an object from a string using the object Template return type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static async Task<T> FromJsonAsync<T>(this string json)
        {
            _logger.DebugFormat($"'{nameof(JsonExtensions)}.{nameof(FromJsonAsync)}' called");

#pragma warning disable CS8603 // Possible null reference return.
            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
#pragma warning restore CS8603 // Possible null reference return.
        }

        /// <summary>
        ///     Parse an object from a string using the object Template return type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T FromJson<T>(this string json)
        {
            _logger.DebugFormat($"'{nameof(JsonExtensions)}.{nameof(FromJson)}' called");

            return FromJsonAsync<T>(json).GetAwaiter().GetResult();
        }

        /// <summary>
        ///     Async Convert an object into a json string object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static async Task<string> ToJsonAsync(this object value)
        {
            _logger.DebugFormat($"'{nameof(JsonExtensions)}.{nameof(ToJsonAsync)}' called");

            return await Task.Run(() => JsonConvert.SerializeObject(value));
        }

        /// <summary>
        ///     Convert an object into a json string object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToJson(this object value)
        {
            _logger.DebugFormat($"'{nameof(JsonExtensions)}.{nameof(ToJson)}' called");

            return ToJsonAsync(value).GetAwaiter().GetResult();
        }

        /// <summary>
        ///     Async Convert a json string to an object of type that is unknown
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        public static async Task<JObject> FromJsonToJObjectAsync(this string json)
        {
            _logger.DebugFormat($"'{nameof(JsonExtensions)}.{nameof(FromJsonToJObjectAsync)}' called");

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
            _logger.DebugFormat($"'{nameof(JsonExtensions)}.{nameof(FromJsonToJObject)}' called");

            return FromJsonToJObjectAsync(json).GetAwaiter().GetResult();
        }

        /// <summary>
        ///     Async Convert a json array string to an object of type that is unknown
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        public static async Task<JArray> FromJsonToJArrayAsync(this string json)
        {
            _logger.DebugFormat($"'{nameof(JsonExtensions)}.{nameof(FromJsonToJArrayAsync)}' called");

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
            _logger.DebugFormat($"'{nameof(JsonExtensions)}.{nameof(FromJsonToJArray)}' called");

            return FromJsonToJArrayAsync(json).GetAwaiter().GetResult();
        }
    }
}