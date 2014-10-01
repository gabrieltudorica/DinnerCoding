namespace SendingEmails
{
    public class HolidayRequest
    {
        public Employee Requester { get; private set; }
        public Employee Manager { get; private set; }

        public TimeInterval TimeInterval { get; private set; }

        public HolidayRequest(Employee requester, Employee manager, TimeInterval timeInterval)
        {
            Requester = requester;
            Manager = manager;
            TimeInterval = timeInterval;
        }
    }
}
