namespace HolidayRequestSender
{
    public class HolidayApplication
    {
        private Employee _employee;
        private Employee _manager;
        private HolidayInterval _holidayInterval;

        public HolidayApplication(Employee employee, Employee manager, HolidayInterval holidayInterval)
        {
            _employee = employee;
            _manager = manager;
            _holidayInterval = holidayInterval;
        }

        public void Request()
        {

        }
    }
}
