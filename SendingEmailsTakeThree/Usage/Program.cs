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

            var holidayRequest = new Holiday(new EmailNotifier());
            holidayRequest.Request(holidayApplication);
            holidayRequest.Approve(holidayApplication);
            holidayRequest.Reject(holidayApplication);
        }
    }
}
