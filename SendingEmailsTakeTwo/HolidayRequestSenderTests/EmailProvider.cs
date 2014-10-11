using System.Configuration;
using System.Net.Mail;

namespace HolidayRequestSenderTests
{
    public class EmailProvider
    {
        public static MailAddress GetCompanyEmployeeEmail(string firstName, string lastName)
        {
            string emailAddress = string.Format("{0}.{1}@{2}",
                firstName, lastName,
                ConfigurationManager.AppSettings["companyHost"]);

            return new MailAddress(emailAddress, firstName + " " + lastName);
        }

        public static MailAddress GetCompanyGenericEmail(string genericAddress)
        {
            string emailAddress = string.Format("{0}@{1}",
               genericAddress,
               ConfigurationManager.AppSettings["companyHost"]);

            return new MailAddress(emailAddress, genericAddress);
        }
    }
}
