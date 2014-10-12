using HolidayRequestSender;
using System;

namespace Usage
{
    class Program
    {
        private static void Main(string[] args)
        {
            var requester = new Employee("James", "Darmody");
            var manager = new Employee("Nucky", "Thompson");
            var oneWeekHolidayStartingTomorrow =
                new HolidayInterval(DateTime.Now.AddDays(1), DateTime.Now.AddDays(8));

            var holidayApplication = new HolidayApplication(
                requester, manager, oneWeekHolidayStartingTomorrow);

            EmailSender.Send(holidayApplication.Create(EmailContentType.Request), 
                "requesterPassword");
            EmailSender.Send(holidayApplication.Create(EmailContentType.Approval),
                "managerPassword");
            EmailSender.Send(holidayApplication.Create(EmailContentType.Rejection),
                "managerPassword");
        }
    }
}
