using System;

namespace HolidayRequestSender
{
    public class HolidayApplication
    {
        private Employee _employee;
        private Employee _manager;
        private DateTime _from;
        private DateTime _to;


        public HolidayApplication(Employee employee, Employee manager, DateTime from, DateTime to)
        {
            _employee = employee;
            _manager = manager;
            _from = from;
            _to = to;
        }

        public void Request()
        {

        }
    }
}
