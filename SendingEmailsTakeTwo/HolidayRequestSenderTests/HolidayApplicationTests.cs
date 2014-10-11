using HolidayRequestSender;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Linq;
using System.Net.Mail;

namespace HolidayRequestSenderTests
{
    [TestClass]
    public class HolidayApplicationTests
    {
        private readonly Employee _requester = new Employee("James", "Darmody");
        private readonly Employee _manager = new Employee("Nucky", "Thompson");

        [TestMethod]
        public void Create_WhenPassingRequestType_ReturnsRequestMail()
        {
            var holidayInterval = new HolidayInterval(
                DateTime.Now.AddDays(1), DateTime.Now.AddDays(8));

            var holidayApplication = new HolidayApplication(
                _requester, _manager, holidayInterval);
            MailMessage requestMail = holidayApplication.Create(EmailContentType.Request);

            Assert.AreEqual(_requester.GetEmail(), requestMail.From);
            Assert.AreEqual(_manager.GetEmail(), requestMail.To);
            Assert.AreEqual("Holiday Request", requestMail.Subject, true);
        }

        [TestMethod]
        public void Create_WhenPassingApprovedType_ReturnsApprovedMail()
        {
            var holidayInterval = new HolidayInterval(
                DateTime.Now.AddDays(1), DateTime.Now.AddDays(8));

            var holidayApplication = new HolidayApplication(
                _requester, _manager, holidayInterval);
            MailMessage requestMail = holidayApplication.Create(EmailContentType.Approval);

            Assert.AreEqual(_manager.GetEmail(), requestMail.From);            
            Assert.AreEqual(_requester.GetEmail(), requestMail.CC.First());            
            Assert.IsTrue(requestMail.Subject.StartsWith("[approved]", 
                StringComparison.InvariantCultureIgnoreCase));

            string hrEmailUser = ConfigurationManager.AppSettings["hrMail"];
            string hrEmailAddress = string.Format("{0}@{1}", hrEmailUser,
                ConfigurationManager.AppSettings["companyHost"]);
            var expectedHrMail = new MailAddress(hrEmailAddress, hrEmailUser);

            Assert.AreEqual(expectedHrMail, requestMail.To);
        }

        [TestMethod]
        public void Create_WhenPassingRejectedType_ReturnsRejectedMail()
        {
            var holidayInterval = new HolidayInterval(
                DateTime.Now.AddDays(1), DateTime.Now.AddDays(8));

            var holidayApplication = new HolidayApplication(
                _requester, _manager, holidayInterval);
            MailMessage requestMail = holidayApplication.Create(EmailContentType.Rejection);

            Assert.AreEqual(_manager.GetEmail(), requestMail.From);
            Assert.AreEqual(_requester.GetEmail(), requestMail.To);
            Assert.IsTrue(requestMail.Subject.StartsWith("[rejected]",
                StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
