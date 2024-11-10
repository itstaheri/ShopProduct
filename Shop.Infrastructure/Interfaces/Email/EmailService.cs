using Shop.Application.Interfaces.Email;
using Shop.Domain.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Shop.Infrastructure.Interfaces.Email
{
    public class EmailService : IEmail
    {
        private string sender;
        private string password;
        public EmailService(IConfiguration configuration)
        {
            sender = configuration.GetSection("SMTPConfig").GetSection("Email").Value;
            password = configuration.GetSection("SMTPConfig").GetSection("Password").Value;
        }
        public void Send(SendEmail email)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(sender);
                mailMessage.To.Add(email.To);
                mailMessage.Subject = email.Subject;
                mailMessage.Body = email.Body;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.server.address";
                smtp.Port = 25;
                smtp.Credentials = new NetworkCredential(sender,password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;


                smtp.Send(mailMessage);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
