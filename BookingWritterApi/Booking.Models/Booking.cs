using Booking.Messages;
namespace Booking.Models
{
    public class Booking
    {
        public Identity Id { get; private set; }
        public BookingDate Interval { get; private set; }
        public BookingDetails Details { get; private set; }

        private Booking(CreateBookingCommandRequest command)
        {
            Id = Identity.Create(command.Id);
            Interval = BookingDate.Create(command.StartDate, command.EndDate);
            Details = BookingDetails.Create(command.RoomId, command.HotelId, command.UserId);
        }

        public static Booking Create(CreateBookingCommandRequest command)
        {
            return new Booking(command);
        }
    }
}
