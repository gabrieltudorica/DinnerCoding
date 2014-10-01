using System;

namespace SendingEmails
{
    public class HolidayRequest
    {
        public string EmployeeName { get; private set; }    
        private string _employeeEmail;
        private string _managerEmail;

        private DateTime _from;
        private DateTime _to;

        public HolidayRequest(string employeeName, string employeeEmail, string managerEmail, DateTime from, DateTime to)
        {
            EmployeeName = employeeName;
            _employeeEmail = employeeEmail;
            _managerEmail = managerEmail;

            _from = from;
            _to = to;
        }
    }
}
