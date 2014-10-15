namespace HolidayRequestSender
{
    public class HolidayApplication
    {
        public Employee Employee { get; private set; }
        public Employee Manager { get; private set; }
        public HolidayInterval HolidayInterval { get; private set; }

        public HolidayApplication(Employee employee, Employee manager, HolidayInterval holidayInterval)
        {
            Employee = employee;
            Manager = manager;
            HolidayInterval = holidayInterval;
        }      
    }
}
