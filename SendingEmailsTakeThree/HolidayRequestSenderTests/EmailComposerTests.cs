﻿using HolidayRequestSender;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Linq;
using System.Net.Mail;

namespace HolidayRequestSenderTests
{
    [TestClass]
    public class EmailComposerTests
    {
        private readonly Employee _requester = new Employee("James", "Darmody");
        private readonly Employee _manager = new Employee("Nucky", "Thompson");
        private readonly HolidayInterval _oneWeekHolidayStartingTomorrow = 
            new HolidayInterval(DateTime.Now.AddDays(1), DateTime.Now.AddDays(8));

        [TestMethod]
        public void CreateRequestMail_ReturnsRequestMail()
        {
            var composer = new EmailComposer(GetHolidayApplication());
            MailMessage requestMail = composer.CreateRequestMail();

            Assert.AreEqual(_requester.GetEmail(), requestMail.From);
            Assert.AreEqual(_manager.GetEmail(), requestMail.To);
            Assert.AreEqual("Holiday Request", requestMail.Subject, true);
        }

        [TestMethod]
        public void CreateApprovalMail_ReturnsApprovedMail()
        {
            var composer = new EmailComposer(GetHolidayApplication());
            MailMessage requestMail = composer.CreateApprovalMail();

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
        public void CreateRejectionMail_ReturnsRejectedMail()
        {
            var composer = new EmailComposer(GetHolidayApplication());
            MailMessage requestMail = composer.CreateRejectionMail();

            Assert.AreEqual(_manager.GetEmail(), requestMail.From);
            Assert.AreEqual(_requester.GetEmail(), requestMail.To);
            Assert.IsTrue(requestMail.Subject.StartsWith("[rejected]",
                StringComparison.InvariantCultureIgnoreCase));
        }

        private HolidayApplication GetHolidayApplication()
        {
            return new HolidayApplication(_requester, _manager, _oneWeekHolidayStartingTomorrow);
        }
    }
}
