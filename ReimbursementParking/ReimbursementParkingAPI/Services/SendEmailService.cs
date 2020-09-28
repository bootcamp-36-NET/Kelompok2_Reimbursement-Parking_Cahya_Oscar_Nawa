using ReimbursementParkingAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.Services
{
    public class SendEmailService
    {
        public void SendEmail(SendEmailVM sendEmailVM)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(sendEmailVM.Email));
                message.From = new MailAddress("xyztechnologyid@gmail.com", "System Admin");
                message.Subject = sendEmailVM.Subject;
                message.Body = sendEmailVM.Body;
                message.IsBodyHtml = true;

                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    client.UseDefaultCredentials = false;
                    client.Port = 587;
                    client.Credentials = new NetworkCredential("xyztechnologyid@gmail.com", "HelloWorld");
                    client.EnableSsl = true;
                    client.Send(message);
                }

            }
        }
    }
}
