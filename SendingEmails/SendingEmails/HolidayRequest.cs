using System.Net.Mail;

namespace SendingEmails
{
    public class HolidayRequest
    {
        public string EmployeeName { get; private set; }
        public MailAddress EmployeeEmail { get; private set; }
        public MailAddress ManagerEmail { get; private set; }

        public TimeInterval TimeInterval { get; private set; }

        public HolidayRequest(string employeeName, MailAddress employeeEmail, MailAddress managerEmail, TimeInterval timeInterval)
        {
            EmployeeName = employeeName;
            EmployeeEmail = employeeEmail;
            ManagerEmail = managerEmail;

            TimeInterval = timeInterval;
        }
    }
}
