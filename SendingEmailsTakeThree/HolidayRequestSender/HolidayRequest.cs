namespace HolidayRequestSender
{
    public class HolidayRequest
    {
        private readonly HolidayApplication _holidayApplication;
        private readonly INotifier _notifier;

        public HolidayRequest(HolidayApplication holidayApplication, INotifier notifier)
        {
            _holidayApplication = holidayApplication;
            _notifier = notifier;
        }

        public void Request()
        {
            _notifier.Request(_holidayApplication);
        }

        public void Approve()
        {
            _notifier.Approve(_holidayApplication);
        }

        public void Reject()
        {
            _notifier.Reject(_holidayApplication);
        }
    }
}
