namespace SendingEmails.Request
{
    public class HolidayRequest
    {
        public Employee.Employee Requester { get; private set; }
        public Employee.Employee Manager { get; private set; }

        public TimeInterval TimeInterval { get; private set; }

        public HolidayRequest(Employee.Employee requester, Employee.Employee manager, TimeInterval timeInterval)
        {
            Requester = requester;
            Manager = manager;
            TimeInterval = timeInterval;
        }
    }
}
