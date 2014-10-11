using System.Configuration;
using System.Net.Mail;

namespace HolidayRequestSender
{
    public class HolidayApplication
    {
        private readonly Employee _employee;
        private readonly Employee _manager;
        private readonly HolidayInterval _holidayInterval;

        public HolidayApplication(Employee employee, Employee manager, HolidayInterval holidayInterval)
        {
            _employee = employee;
            _manager = manager;
            _holidayInterval = holidayInterval;
        }

        public MailMessage Create(EmailContentType mailType)
        {
            if (mailType == EmailContentType.Request)
            {
                return CreateRequestMail();
            }

            return mailType == EmailContentType.Approval ? 
                                CreateApprovalMail() : 
                                CreateRejectionMail();
        }

        private MailMessage CreateRequestMail()
        {
            return new MailMessage(_employee.GetEmail(), _manager.GetEmail())
            {
                Subject = "Holiday Request",
                Body = "Hi " + _manager.GetFirstName() + "," +
                        "\n\n" +
                        "Please approve my holiday request starting from " +
                        _holidayInterval.GetStartDate().ToShortDateString() +
                        "until " +
                        _holidayInterval.GetEndDate().ToShortDateString() +
                        "\n\n" +
                        "Thank you!"                    
            };
        }

        private MailMessage CreateApprovalMail()
        {
            var hrMail = new MailAddress(
                string.Format("{0}@{1}",
                    ConfigurationManager.AppSettings["hrMail"],
                    ConfigurationManager.AppSettings["companyHost"]), 
                    ConfigurationManager.AppSettings["hrMail"]);

            var approvalMail = new MailMessage(_manager.GetEmail(), hrMail)
            {
                Subject = "[Approved] Holiday Request",
                Body = "Hi, " + 
                        "\n\n" +
                        _employee.GetFirstName() + "'s holiday holiday request starting from " +
                        _holidayInterval.GetStartDate().ToShortDateString() +
                        "until " +
                        _holidayInterval.GetEndDate().ToShortDateString() +
                        " has been approved." +
                        "\n\n" +
                        "Thank you!"
            };

            approvalMail.CC.Add(_employee.GetEmail());
            return approvalMail;
        }

        private MailMessage CreateRejectionMail()
        {
            return new MailMessage(_manager.GetEmail(), _employee.GetEmail())
            {
                Subject = "[Rejected] Holiday Request",
                Body = "Hi " + _employee.GetFirstName() + "," +
                        "\n\n" +
                        "Unfortunately, your holiday request starting from " +
                        _holidayInterval.GetStartDate().ToShortDateString() +
                        "until " +
                        _holidayInterval.GetEndDate().ToShortDateString() +
                        "cannot be approved during this timeframe." + 
                        "\n\n" +
                        "Thank you!"
            };
        }
    }
}
