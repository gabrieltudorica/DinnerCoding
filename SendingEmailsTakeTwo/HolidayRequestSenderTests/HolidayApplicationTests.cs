using System;
using System.Net.Mail;
using HolidayRequestSender;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HolidayRequestSenderTests
{
    [TestClass]
    public class HolidayApplicationTests
    {
        [TestMethod]
        public void Create_WhenPassingRequestType_ReturnsRequestMail()
        {
            var requester = new Employee("James", "Darmody");
            var manager = new Employee("Nucky", "Thompson");            
            var holidayInterval = new HolidayInterval(
                DateTime.Now.AddDays(1), DateTime.Now.AddDays(8));

            var holidayApplication = new HolidayApplication(requester, manager, holidayInterval);
            MailMessage requestMail = holidayApplication.Create(EmailContentType.Request);

            Assert.AreEqual(requester.GetEmail(), requestMail.From);
            Assert.AreEqual(manager.GetEmail(), requestMail.To);
            Assert.AreEqual("Holiday Request", requestMail.Subject, true);
        }
    }
}
