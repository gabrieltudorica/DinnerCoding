using System;

namespace HolidayRequestSender
{
    public class HolidayApplication
    {
        private string _employeeFullName;
        private string _employeeEmail;
        private string _managerEmail;
        private DateTime _from;
        private DateTime _to;


        public HolidayApplication(string employeeFullName, string employeeEmail, string managerEmail, DateTime from, DateTime to)
        {
            _employeeFullName = employeeFullName;
            _employeeEmail = employeeEmail;
            _managerEmail = managerEmail;
            _from = from;
            _to = to;
        }

        public void Request()
        {

        }
    }
}
