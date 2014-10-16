namespace HolidayRequestSender
{
    public class EmailNotifier : INotifier
    {
        public void Request(HolidayApplication holidayApplication)
        {
            var composer = new EmailComposer(holidayApplication);
            Email.Send(composer.CreateRequestMail());
        }

        public void Approve(HolidayApplication holidayApplication)
        {
            var composer = new EmailComposer(holidayApplication);
            Email.Send(composer.CreateApprovalMail());
        }

        public void Reject(HolidayApplication holidayApplication)
        {
            var composer = new EmailComposer(holidayApplication);
            Email.Send(composer.CreateRejectionMail());
        }
    }
}
