using System.Configuration;

namespace SendingEmails.Sender
{
    public class EmailSenderConfig
    {
        public string SmtpHost
        {
            get { return ConfigurationManager.AppSettings["smtpHost"]; } 
        }

        public int SmtpPort
        {
            get { return int.Parse(ConfigurationManager.AppSettings["smtpPort"]); }
        }

        public string AppEmail
        {
            get { return ConfigurationManager.AppSettings["appEmail"]; }
        }

        public string AppEmailPassword
        {
            get { return ConfigurationManager.AppSettings["appEmailPassword"]; }
        }
    }
}
