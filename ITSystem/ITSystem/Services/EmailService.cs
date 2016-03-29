using ITSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace ITSystem.Services
{
    public static class EmailService
    {
        public static string Pass { get; set; }
        public static string Subject { get; set; }
        public static string Body { get; set; }
        public static List<Candidate> Recievers { get; set; }

        public static void SendEmail()
        {
            try
            {
                SmtpClient ss = new SmtpClient("smtp.gmail.com", 587);
                ss.EnableSsl = true;
                ss.DeliveryMethod = SmtpDeliveryMethod.Network;
                ss.UseDefaultCredentials = false;
                ss.Credentials = new NetworkCredential("testforhallmanager@gmail.com", "hallmanager");
                
                foreach (var item in Recievers)
                {
                    MailMessage mm = new MailMessage("testforhallmanager@gmail.com", item.Email, Subject, "Hello, " + item.FirstName + " " + item.LastName + ", "+Environment.NewLine+ Body);
                    mm.BodyEncoding = UTF8Encoding.UTF8;
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    ss.Send(mm);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}