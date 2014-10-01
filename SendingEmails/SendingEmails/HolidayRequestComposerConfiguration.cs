using System.Configuration;

namespace SendingEmails
{
    public class HolidayRequestComposerConfiguration
    {
        public string HrMail
        {
            get
            {
                return string.Format("{0}@{1}", ConfigurationManager.AppSettings["hrMail"],
                                     ConfigurationManager.AppSettings["companyHost"]);
            }
        }
    }
}
