using System;

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
  
            if(string.IsNullOrEmpty(_request.EmployeeName))
            {
                throw  new ArgumentException();
            }

            if(_request.TimeInterval.From == DateTime.MinValue || 
               _request.TimeInterval.To == DateTime.MinValue)
            {
                throw new ArgumentException();
            }
        }
    }
}
