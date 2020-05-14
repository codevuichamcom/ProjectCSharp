using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Project.Ultilities
{
    public class SendMail
    {
        public static void Send(string mailTo, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("lehongquan15a@gmail.com");
            mail.To.Add(mailTo);
            mail.Subject = subject;
            mail.Body += body;

            mail.IsBodyHtml = true;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("lehongquan15a@gmail.com", "qU@nIhh313O736");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}