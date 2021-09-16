using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Contracts
{
    public interface IBookingRepository
    {
        /// <summary>
        /// Gets all bookings.
        /// </summary>
        /// <returns>All the bookings from the system.</returns>
        Task<IList<Models.Booking>> GetAll();
        
        /// <summary>
        /// Gets the bookings of a specific user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A list of bookings for the specified user.</returns>
        Task<IList<Models.Booking>> GetByUserId(Guid userId);

        /// <summary>
        /// Gets the booking by specific id.
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns>The booking with the specified id.</returns>
        Task<Models.Booking> GetById(Guid bookingId);
    }
}
