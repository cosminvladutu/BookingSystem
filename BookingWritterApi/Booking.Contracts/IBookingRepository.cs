using System;
using System.Threading.Tasks;

namespace Booking.Contracts
{
    public interface IBookingRepository
    {
        /// <summary>
        /// Save a Booking.
        /// </summary>
        /// <param name="booking">The booking.</param>
        Task Save(Models.Booking booking);
    }
}
