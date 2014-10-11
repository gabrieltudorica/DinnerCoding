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
            return new MailMessage(_employee.GetEmail(), _manager.GetEmail())
            {
                Subject = "Holiday Request",
                Body = string.Format("Please approve my holiday request from {0} to {1}",
                    _holidayInterval.GetStartDate().ToShortDateString(), 
                    _holidayInterval.GetEndDate().ToShortDateString()) 
            };
        }
    }
}
