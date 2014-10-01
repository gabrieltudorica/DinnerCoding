using System;
using System.Net.Mail;

namespace SendingEmails
{
    public class HolidayRequest
    {
        public string EmployeeName { get; private set; }
        public MailAddress EmployeeEmail { get; private set; }
        public MailAddress ManagerEmail { get; private set; }

        public DateTime From { get; private set; }
        public DateTime To { get; private set; }

        public HolidayRequest(string employeeName, MailAddress employeeEmail, MailAddress managerEmail, DateTime from, DateTime to)
        {
            EmployeeName = employeeName;
            EmployeeEmail = employeeEmail;
            ManagerEmail = managerEmail;

            From = from;
            To = to;
        }
    }
}
