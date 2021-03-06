﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SendingEmails.Employee;
using System;

namespace SendingEmailsTests
{
    [TestClass]
    public class EmployeeTests
    {
        private const string FirstName = "firstName";
        private const string LastName = "lastName";

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyStringFirstName_ThrowsException()
        {
            new Employee(string.Empty, LastName, GetConfigurationMock());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyStringLastName_ThrowsException()
        {
            new Employee(FirstName, string.Empty, GetConfigurationMock());
        }

        [TestMethod]
        public void EmployeeName_ReturnsCorrectFullName()
        {
            var employee = new Employee(FirstName, LastName, GetConfigurationMock());
            Assert.AreEqual(employee.EmployeeName, "firstName lastName");
        }

        [TestMethod]
        public void EmployeeEmail_ComputedCorrectly()
        {
            IEmployeeConfig configMock = GetConfigurationMock();

            var employee = new Employee(FirstName, LastName, configMock);
            string expectedMail = FirstName + "." + LastName + "@" + configMock.CompanyHost; 
            
            Assert.AreEqual(employee.GetEmployeeEmail().Address, expectedMail);
        }

        private IEmployeeConfig GetConfigurationMock()
        {
            var employeeConfigMock = new Mock<IEmployeeConfig>();
            employeeConfigMock.Setup(m => m.CompanyHost).Returns("dummyHost.com");

            return employeeConfigMock.Object;
        }
    }
}
