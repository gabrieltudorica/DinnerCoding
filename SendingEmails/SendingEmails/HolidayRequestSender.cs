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
                throw new ArgumentNullException("Request cannot be null");
            }          
  
            if(string.IsNullOrEmpty(_request.EmployeeName))
            {
                throw  new ArgumentException();
            }
        }
    }
}
