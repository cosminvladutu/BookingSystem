using System;

namespace Booking.Models
{
    public class BookingDate
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        private BookingDate(DateTime startDate, DateTime endDate)
        {
            Validate(startDate, endDate);

            StartDate = startDate;
            EndDate = endDate;
        }

        internal static BookingDate Create(DateTime startDate, DateTime endDate)
        {
            return new BookingDate(startDate, endDate);
        }

        private void Validate(DateTime startDate, DateTime endDate)
        {
            if (startDate >= endDate)
            {
                throw new ArgumentException("start date is greater or equal to end date");
            }

            if (startDate == DateTime.MinValue)
            {
                throw new ArgumentException("start booking date is min value");
            }

            if (startDate == DateTime.MaxValue)
            {
                throw new ArgumentException("start booking date is max value");
            }

            if (endDate == DateTime.MinValue)
            {
                throw new ArgumentException("end booking date is min value");
            }

            if (endDate == DateTime.MaxValue)
            {
                throw new ArgumentException("end booking date is max value");
            }
        }
    }
}