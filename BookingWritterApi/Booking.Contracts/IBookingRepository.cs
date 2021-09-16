using System;
using System.Threading.Tasks;

namespace Booking.Contracts
{
    public interface IBookingRepository
    {
        /// <summary>
        /// Create a Booking.
        /// </summary>
        /// <param name="tenant">Tenant.</param>
        Task Create(Models.Booking tenant);
    }
}
