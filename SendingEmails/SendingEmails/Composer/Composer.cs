using System;
using System.Net.Mail;
using SendingEmails.Request;

namespace SendingEmails.Composer
{
    public class Composer
    {
        private readonly HolidayRequest _request;
        private readonly IComposerConfig _config;

        public Composer(HolidayRequest request, IComposerConfig config)
        {
            _request = request;
            _config = config;

            ValidateRequest();
        }

        private void ValidateRequest()
        {
            if(_request == null)
            {
                throw new ArgumentNullException("Request");
            }          

            if(_request.TimeInterval.From == DateTime.MinValue || 
               _request.TimeInterval.To == DateTime.MinValue)
            {
                throw new ArgumentException("The time intervals cannot have the minimum value");
            }

            if(_request.TimeInterval.To <= _request.TimeInterval.From)
            {
                throw new ArgumentException("The \"To\" time interval must be set to a more recent date than the \"From\" time interval");
            }
        }

        public MailMessage ComposeByStatus(RequestStatus status)
        {
            if(status == RequestStatus.Requested)
            {
                return ComposeRequested();
            }

            return status == RequestStatus.Rejected ? ComposeRejected() : ComposeApproved();
        }

        private MailMessage ComposeRequested()
        {
            var mail = new MailMessage(_request.Requester.GetEmployeeEmail(), _request.Manager.GetEmployeeEmail())
                           {
                               Subject = "Holiday Request",
                               IsBodyHtml = false,
                               Body = "Hi, " +
                                      "\n" +
                                      "\n" +
                                      "Please approve my holiday request starting from " +
                                      _request.TimeInterval.From.ToShortDateString() +
                                      "until " +
                                      _request.TimeInterval.To.ToShortDateString() +
                                      "\n" +
                                      "\n" +
                                      "Thank you!"
                           };

            return mail;
        }

        private MailMessage ComposeRejected()
        {
            var mail = new MailMessage(_request.Manager.GetEmployeeEmail(), _request.Requester.GetEmployeeEmail())
                           {
                               Subject = "[Rejected] Holiday Request",
                               IsBodyHtml = false,
                               Body = "Hi, " +
                                      "\n" +
                                      "\n" +
                                      "Your request was rejected!" +
                                      "\n" +
                                      "\n" +
                                      "Thank you!"
                           };

            return mail;
        }

        private MailMessage ComposeApproved()
        {
            var mail = new MailMessage(_request.Manager.GetEmployeeEmail(), new MailAddress(_config.HrMail))
                           {
                               Subject = "[Approved] Holiday Request",
                               IsBodyHtml = false,
                               Body = "Hi, " +
                                      "\n" +
                                      "\n" +
                                      "Your request was approved! " +
                                      "\n" +
                                      "\n" +
                                      "Thank you!",
                           };
            mail.CC.Add(_request.Requester.GetEmployeeEmail());            

            return mail;
        }
    }
}
