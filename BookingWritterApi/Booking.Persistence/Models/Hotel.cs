using System;
using System.Collections.Generic;

namespace Booking.Persistence.Models
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public IList<Room> RoomList { get; set; }
    }
}
