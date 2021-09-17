using Booking.Messages;
using System;

namespace BookingWritterApi.Infrastructure.ViewModels
{
    public class BookingVm
    {
        /// <summary>
        /// The identifier of the booking, so that if 2 bookings will be received with the same id we will not save 2 different
        /// bookings.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The identifier of the user who made the booking.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// The Room identifier.
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// The start date of the booking.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The end date of the booking.
        /// </summary>
        public DateTime EndDate { get; set; }

        internal bool IsValid()
        {
            if (Id == Guid.Empty || UserId == Guid.Empty || RoomId == Guid.Empty || StartDate == DateTime.MinValue
                || EndDate == DateTime.MinValue || StartDate == DateTime.MaxValue || EndDate == DateTime.MaxValue || StartDate > EndDate)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public static class BookingVmExtensions
    {
        internal static CreateBookingCommandRequest ToCreateCommand(this BookingVm vm)
        {
            return new CreateBookingCommandRequest
            {
                Id = vm.Id,
                UserId = vm.UserId,
                RoomId = vm.RoomId,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate
            };
        }
    }
}
