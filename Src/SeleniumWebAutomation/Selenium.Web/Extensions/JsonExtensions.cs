using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Selenium.Web.Tests.Extensions
{
   public static class JsonExtensions
   {
      public static async Task<T> FromJson<T>(this string json)
      {
         return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
      }

      public static async Task<string> ToJson(this object value)
      {
         return await Task.Run(() => JsonConvert.SerializeObject(value));
      }

      /// <summary>
      /// Parses the json.
      /// </summary>
      /// <param name="json">The json.</param>
      /// <returns></returns>
      public static async Task<JObject> FromJsonToJObject(this string json)
      {
         if (string.IsNullOrEmpty(json))
         {
            return null;
         }

         return await Task.Run(() => JObject.Parse(json));
      }

      /// <summary>
      /// Parses the json array.
      /// </summary>
      /// <param name="json">The json.</param>
      /// <returns></returns>
      public static async Task<JArray> FromJsonToJArray(this string json)
      {
         if (string.IsNullOrEmpty(json))
         {
            return null;
         }

         return await Task.Run(() => JArray.Parse(json));
      }
   }
}