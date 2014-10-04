using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SendingEmails.Composer;
using SendingEmails.Employee;
using SendingEmails.Request;
using System;
using System.Net.Mail;

namespace SendingEmailsTests
{
    [TestClass]
    public class ComposerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullRequest_ThrowsException()
        {
            new Composer(null, GetConfig());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DefaultRequestInterval_ThrowsException()
        {
            var employee = GetEmployee("firstName", "lastName");
            
            var request = new HolidayRequest(employee, employee, new TimeInterval());
            new Composer(request, GetConfig());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToIntervalEqualToFromDate_ThrowsException()
        {
            var now = DateTime.Now;
            var employee = GetEmployee("firstName", "lastName");            

            var request = new HolidayRequest(employee, employee, new TimeInterval{From = now, To = now});
            new Composer(request, GetConfig());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToIntervalLowerThanFromDate_ThrowsException()
        {
            var now = DateTime.Now;
            var employee = GetEmployee("firstName", "lastName");

            var request = new HolidayRequest(employee, employee, new TimeInterval { From = now, To = now.AddDays(-1) });
            new Composer(request, GetConfig());
        }

        [TestMethod]
        public void RequestSentToManager_IsCorrect()
        {
            var now = DateTime.Now;
            var requester = GetEmployee("John", "Watson");
            var manager = GetEmployee("Sherlock", "Holmes");

            var request = new HolidayRequest(requester, manager , new TimeInterval { From = now.AddDays(1), To = now.AddDays(8) });
            var composer = new Composer(request, GetConfig());
            MailMessage mail = composer.ComposeByStatus(RequestStatus.Requested);

            Assert.IsTrue(mail.Subject.StartsWith("Holiday Request"));
            Assert.AreEqual(mail.From.Address, requester.GetEmployeeEmail().Address);
            Assert.AreEqual(mail.To[0].Address, manager.GetEmployeeEmail().Address);
        }

        [TestMethod]
        public void RejectedRequest_IsCorrect()
        {
            var now = DateTime.Now;
            var requester = GetEmployee("John", "Watson");
            var manager = GetEmployee("Sherlock", "Holmes");

            var request = new HolidayRequest(requester, manager, new TimeInterval { From = now.AddDays(1), To = now.AddDays(8) });
            var composer = new Composer(request, GetConfig());
            MailMessage mail = composer.ComposeByStatus(RequestStatus.Rejected);

            Assert.IsTrue(mail.Subject.StartsWith("[Rejected]"));
            Assert.AreEqual(mail.From.Address, manager.GetEmployeeEmail().Address);
            Assert.AreEqual(mail.To[0].Address, requester.GetEmployeeEmail().Address);
        }

        [TestMethod]
        public void ApprovedRequest_IsCorrect()
        {
            var now = DateTime.Now;
            var requester = GetEmployee("John", "Watson");
            var manager = GetEmployee("Sherlock", "Holmes");

            var request = new HolidayRequest(requester, manager, new TimeInterval { From = now.AddDays(1), To = now.AddDays(8) });
            var composer = new Composer(request, GetConfig());
            MailMessage mail = composer.ComposeByStatus(RequestStatus.Approved);

            Assert.IsTrue(mail.Subject.StartsWith("[Approved]"));
            Assert.AreEqual(mail.From.Address, manager.GetEmployeeEmail().Address);
            Assert.AreEqual(mail.To[0].Address, "hr@dummyHost.com");
            Assert.AreEqual(mail.CC[0].Address, requester.GetEmployeeEmail().Address);
        }

        private IComposerConfig GetConfig()
        {
            var composerConfig = new Mock<IComposerConfig>();
            composerConfig.Setup(m => m.HrMail).Returns("hr@dummyHost.com");

            return composerConfig.Object;
        }

        private Employee GetEmployee(string firstName, string lastName)
        {
            var employeeConfigMock = new Mock<IEmployeeConfig>();
            employeeConfigMock.Setup(m => m.CompanyHost).Returns("someHost.com");

            return new Employee(firstName, lastName, employeeConfigMock.Object);
        }
    }
}
