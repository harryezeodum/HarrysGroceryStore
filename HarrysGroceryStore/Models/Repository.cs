using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class Repository
    {
        public static List<User> responses = new List<User>();
        public static IEnumerable<User> Responses = responses;
        public static void AddResponse(User response)
        {
            responses.Add(response);
        }

        public static void EditResponse(User response)
        {
            responses.Add(response);

        }
    }
}
