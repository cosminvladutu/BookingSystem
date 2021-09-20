using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Persistence.Models
{
   public class Booking
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public User User { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid RoomId { get; set; }
        public Guid HotelId { get; set; }
    }
}
