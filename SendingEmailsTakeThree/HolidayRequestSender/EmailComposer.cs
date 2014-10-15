using System.Configuration;
using System.Net.Mail;

namespace HolidayRequestSender
{
    public class EmailComposer
    {
        private readonly HolidayApplication _holidayApplication;
       
        public EmailComposer(HolidayApplication holidayApplication)
        {
            _holidayApplication = holidayApplication;
        }

        public MailMessage CreateRequestMail()
        {
            return new MailMessage(_holidayApplication.Employee.GetEmail(), _holidayApplication.Manager.GetEmail())
            {
                Subject = "Holiday Request",
                Body = "Hi " + _holidayApplication.Manager.GetFirstName() + "," +
                        "\n\n" +
                        "Please approve my holiday request starting from " +
                        _holidayApplication.HolidayInterval.GetStartDate().ToShortDateString() +
                        " until " +
                        _holidayApplication.HolidayInterval.GetEndDate().ToShortDateString() +
                        "\n\n" +
                        "Thank you!"
            };
        }

        public MailMessage CreateApprovalMail()
        {
            var approvalMail = new MailMessage(_holidayApplication.Manager.GetEmail(), GetHrEmail())
            {
                Subject = "[Approved] Holiday Request",
                Body = "Hi, " +
                        "\n\n" +
                        _holidayApplication.Employee.GetFirstName() + "'s holiday holiday request starting from " +
                        _holidayApplication.HolidayInterval.GetStartDate().ToShortDateString() +
                        " until " +
                        _holidayApplication.HolidayInterval.GetEndDate().ToShortDateString() +
                        " has been approved." +
                        "\n\n" +
                        "Thank you!"
            };

            approvalMail.CC.Add(_holidayApplication.Employee.GetEmail());

            return approvalMail;
        }

        public MailMessage CreateRejectionMail()
        {
            return new MailMessage(_holidayApplication.Manager.GetEmail(), _holidayApplication.Employee.GetEmail())
            {
                Subject = "[Rejected] Holiday Request",
                Body = "Hi " + _holidayApplication.Employee.GetFirstName() + "," +
                        "\n\n" +
                        "Unfortunately, your holiday request starting from " +
                        _holidayApplication.HolidayInterval.GetStartDate().ToShortDateString() +
                        " until " +
                        _holidayApplication.HolidayInterval.GetEndDate().ToShortDateString() +
                        " cannot be approved during this timeframe." +
                        "\n\n" +
                        "Thank you!"
            };
        }

        private static MailAddress GetHrEmail()
        {
            return new MailAddress(
                string.Format("{0}@{1}",
                    ConfigurationManager.AppSettings["hrMail"],
                    ConfigurationManager.AppSettings["companyHost"]),
                ConfigurationManager.AppSettings["hrMail"]);
        }
    }
}
