namespace HolidayRequestSender
{
    public interface INotifier
    {
        void Request(HolidayApplication holidayApplication);
        void Approve(HolidayApplication holidayApplication);
        void Reject(HolidayApplication holidayApplication);
    }
}
