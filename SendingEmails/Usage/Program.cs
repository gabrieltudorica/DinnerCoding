using SendingEmails.Composer;
using SendingEmails.Employee;
using SendingEmails.Request;
using SendingEmails.Sender;
using System;
using System.Net.Mail;

namespace Usage
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeConfig = new EmployeeConfig();
            var requester = new Employee("John", "Watson", employeeConfig);
            var manager = new Employee("Sherlock", "Holmes", employeeConfig);

            var request = new HolidayRequest(requester, manager, OneWeekHolidayFromTomorrow());
            var composer = new Composer(request, new ComposerConfig());

            SendMail(composer.ComposeByStatus(RequestStatus.Approved));
            SendMail(composer.ComposeByStatus(RequestStatus.Rejected));
            SendMail(composer.ComposeByStatus(RequestStatus.Requested));                      
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
