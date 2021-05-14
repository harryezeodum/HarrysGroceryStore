using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public interface IEmailRepository
    {
        public void SendEmail(string to, string subject, string body);
    }
}
