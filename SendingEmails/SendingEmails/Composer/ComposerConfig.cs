using System.Configuration;

namespace SendingEmails.Composer
{
    public class ComposerConfig : IComposerConfig
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
