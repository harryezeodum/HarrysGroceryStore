using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class GmailEmailRepository : IEmailRepository
    {
        public void SendEmail(string to, string subject, string body)
        {
            try
            {

                MailMessage email = new MailMessage();
                email.From = new MailAddress("harrysgrocerystore@gmail.com");
                email.To.Add(to);
                email.To.Add("harrysgrocerystore@gmail.com");
                email.Subject = subject;
                email.Body = body;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("harrysgrocerystore@gmail.com", "Adminone");
                smtp.EnableSsl = true;
                smtp.Send(email);
            }
            catch (Exception e)
            {
            }

        }
    }
}
