using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace HolidayRequestSender
{
    public class Email
    {
        public static void Send(MailMessage mail)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.Host = ConfigurationManager.AppSettings["smtpHost"];
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["smtpPort"]);
                smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["appUsername"],
                                                         ConfigurationManager.AppSettings["appPassword"]);
                smtp.EnableSsl = true;

                smtp.Send(mail);
            }
        }
    }
}
