using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCrossDemo.Core.Infrastructure.Extensions
{
    public static class JsonExtensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpResponseMessage response)
        {
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString.ToObject<T>();
        }

        public static T ToObject<T>(this string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static StringContent ToStringContent<T>(this T obj)
        {
            return ToStringContent(obj, "application/json");
        }

        public static StringContent ToStringContent<T>(this T obj, string contentType)
        {
            string json = JsonConvert.SerializeObject(obj);
            return new StringContent(json, Encoding.UTF8, contentType);
        }


    }
}
