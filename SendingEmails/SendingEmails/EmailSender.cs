using System.Net;
using System.Net.Mail;

namespace SendingEmails
{
    public class EmailSender
    {
        private readonly MailMessage _mail;
        private readonly EmailSenderConfiguration _config;

        public EmailSender(EmailSenderConfiguration config, MailMessage mail)
        {
            _mail = mail;
            _config = config;
        }

        public void Send()
        {            
            using (var smtp = new SmtpClient())
            {
                smtp.Host = _config.SmtpHost;
                smtp.Port = _config.SmtpPort;
                smtp.Credentials = new NetworkCredential(_config.AppEmail, _config.AppEmailPassword);
                smtp.EnableSsl = true;

                smtp.Send(_mail);
            }
        }        
    }
}
