using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace HolidayRequestSender
{
    public class EmailSender
    {
        public static void Send(MailMessage mail, string senderPassword)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.Host = ConfigurationManager.AppSettings["smtpHost"];
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["smtpPort"]);
                smtp.Credentials = new NetworkCredential(mail.From.Address, senderPassword);
                smtp.EnableSsl = true;

                smtp.Send(mail);
            }
        }
    }
}
