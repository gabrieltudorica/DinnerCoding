using System.Configuration;

namespace SendingEmails
{
    public class EmployeeConfiguration : IEmployeeConfiguration
    {
        public string CompanyHost
        {
            get { return ConfigurationManager.AppSettings["companyHost"]; }
        }
    }
}
