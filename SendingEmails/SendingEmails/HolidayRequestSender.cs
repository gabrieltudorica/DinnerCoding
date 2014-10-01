using System;
using System.Net.Mail;

namespace SendingEmails
{
    public class HolidayRequestSender
    {
        private readonly HolidayRequest _request;

        public HolidayRequestSender(HolidayRequest request)
        {
            _request = request;
            
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
    }
}
