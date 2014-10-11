using System;
using System.Configuration;
using System.Linq;
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

        [TestMethod]
        public void Create_WhenPassingApprovedType_ReturnsApprovedMail()
        {
            var requester = new Employee("James", "Darmody");
            var manager = new Employee("Nucky", "Thompson");
            var holidayInterval = new HolidayInterval(
                DateTime.Now.AddDays(1), DateTime.Now.AddDays(8));

            var holidayApplication = new HolidayApplication(requester, manager, holidayInterval);
            MailMessage requestMail = holidayApplication.Create(EmailContentType.Approval);

            Assert.AreEqual(manager.GetEmail(), requestMail.From);            
            Assert.AreEqual(requester.GetEmail(), requestMail.CC.First());            
            Assert.IsTrue(requestMail.Subject.StartsWith("[approved]", 
                StringComparison.InvariantCultureIgnoreCase));

            var hrMail = new MailAddress(
                string.Format("{0}@{1}",
                    ConfigurationManager.AppSettings["hrMail"],
                    ConfigurationManager.AppSettings["companyHost"]));
            Assert.AreEqual(hrMail, requestMail.To);
        }

        [TestMethod]
        public void Create_WhenPassingRejectedType_ReturnsRejectedMail()
        {
            var requester = new Employee("James", "Darmody");
            var manager = new Employee("Nucky", "Thompson");
            var holidayInterval = new HolidayInterval(
                DateTime.Now.AddDays(1), DateTime.Now.AddDays(8));

            var holidayApplication = new HolidayApplication(requester, manager, holidayInterval);
            MailMessage requestMail = holidayApplication.Create(EmailContentType.Rejection);

            Assert.AreEqual(manager.GetEmail(), requestMail.From);
            Assert.AreEqual(requester.GetEmail(), requestMail.To);
            Assert.IsTrue(requestMail.Subject.StartsWith("[rejected]",
                StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
