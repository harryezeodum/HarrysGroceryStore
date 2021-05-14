using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Infrastructure
{
    public static class SessionExtensions
    {
        public static T GetJson<T>(this ISession session, string key)
        {
            string sessionJsonString = session.GetString(key);
            if (sessionJsonString == null)
            {
                return default(T);
            }
            T result = JsonConvert.DeserializeObject<T>(sessionJsonString);
            return result;
        }

        public static void SetJson(this ISession session, string key, object value)
        {
            string valueJsonString = JsonConvert.SerializeObject(value);
            session.SetString(key, valueJsonString);
        }
    }
}
