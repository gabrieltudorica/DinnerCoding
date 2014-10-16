namespace HolidayRequestSender
{
    public class Holiday
    {
        private readonly INotifier _notifier;

        public Holiday(INotifier notifier)
        {
            _notifier = notifier;
        }

        public void Request(HolidayApplication holidayApplication)
        {
            _notifier.Request(holidayApplication);
        }

        public void Approve(HolidayApplication holidayApplication)
        {
            _notifier.Approve(holidayApplication);
        }

        public void Reject(HolidayApplication holidayApplication)
        {
            _notifier.Reject(holidayApplication);
        }
    }
}
