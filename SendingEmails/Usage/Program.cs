﻿using SendingEmails;
using SendingEmails.Composer;
using SendingEmails.Employee;
using SendingEmails.Sender;
using System;
using System.Net.Mail;

namespace Usage
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee requester = GetEmployee("John", "Watson");
            Employee manager = GetEmployee("Sherlock", "Holmes");
                        
            Composer composer = GetComposer(requester, manager);

            SendMail(composer.ComposeByStatus(RequestStatus.Approved));
            SendMail(composer.ComposeByStatus(RequestStatus.Rejected));
            SendMail(composer.ComposeByStatus(RequestStatus.Requested));                      
        }

        private static Employee GetEmployee(string firstName, string lastName)
        {
            var employeeConfig = new EmployeeConfig();
            return new Employee(firstName, lastName, employeeConfig);
        }       

        private static Composer GetComposer(Employee requester, Employee manager)
        {
            var request = new HolidayRequest(requester, manager, OneWeekHolidayFromTomorrow());
            return new Composer(request, new ComposerConfig());
        }

        private static TimeInterval OneWeekHolidayFromTomorrow()
        {
            var now = DateTime.Now;
            return new TimeInterval { From = now.AddDays(1), To = now.AddDays(8) };
        }

        private static void SendMail(MailMessage mail)
        {
            var emailSender = new EmailSender(new EmailSenderConfig(), mail);
            emailSender.Send();
        }
    }
}