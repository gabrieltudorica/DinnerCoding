using System;
using HolidayRequestSender;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HolidayRequestSenderTests
{
    [TestClass]
    public class HolidayRequestTests
    {
        private readonly Employee _requester = new Employee("James", "Darmody");
        private readonly Employee _manager = new Employee("Nucky", "Thompson");
        private readonly HolidayInterval _oneWeekHolidayStartingTomorrow =
            new HolidayInterval(DateTime.Now.AddDays(1), DateTime.Now.AddDays(8));

        [TestMethod]
        public void Request_CallsNotifyRequest()
        {
            var holidayApplication = GetHolidayApplication();

            var notifierMock = new Mock<INotifier>();
            notifierMock.Setup(m => m.Request(It.IsAny<HolidayApplication>())).Verifiable();

            var holidayRequest = new Holiday(notifierMock.Object);
            holidayRequest.Request(holidayApplication);

            notifierMock.Verify(m=>m.Request(holidayApplication));
        }

        [TestMethod]
        public void Approve_CallsNotifyApprove()
        {
            var holidayApplication = GetHolidayApplication();

            var notifierMock = new Mock<INotifier>();
            notifierMock.Setup(m => m.Approve(It.IsAny<HolidayApplication>())).Verifiable();

            var holidayRequest = new Holiday(notifierMock.Object);
            holidayRequest.Approve(holidayApplication);

            notifierMock.Verify(m => m.Approve(holidayApplication));
        }

        [TestMethod]
        public void Reject_CallsNotifyReject()
        {
            var holidayApplication = GetHolidayApplication();

            var notifierMock = new Mock<INotifier>();
            notifierMock.Setup(m => m.Reject(It.IsAny<HolidayApplication>())).Verifiable();

            var holidayRequest = new Holiday(notifierMock.Object);
            holidayRequest.Reject(holidayApplication);

            notifierMock.Verify(m => m.Reject(holidayApplication));
        }

        private HolidayApplication GetHolidayApplication()
        {
            return new HolidayApplication(_requester, _manager, _oneWeekHolidayStartingTomorrow);
        }
    }
}
