using System;

namespace HolidayRequestSender
{
    public class HolidayInterval
    {
        private readonly DateTime _from;
        private readonly DateTime _to;

        public HolidayInterval(DateTime from, DateTime to)
        {
            _from = from;
            _to = to;
            
            Validate();
        }

        private void Validate()
        {
            if ((_from == DateTime.MinValue) || (_to == DateTime.MinValue) || _from > _to)
            {
                throw new ArgumentException("From and To time intervals cannot have the default (min) value. " +
                                            "From date must also be more recent than the To date.");
            }
        }

        public DateTime GetStartDate()
        {
            return _from;
        }

        public DateTime GetEndDate()
        {
            return _to;
        }
    }
}
