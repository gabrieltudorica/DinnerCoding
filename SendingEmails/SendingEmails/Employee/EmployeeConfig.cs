using System.Configuration;

namespace SendingEmails.Employee
{
    public class EmployeeConfig : IEmployeeConfig
    {
        public string CompanyHost
        {
            get { return ConfigurationManager.AppSettings["companyHost"]; }
        }
    }
}
