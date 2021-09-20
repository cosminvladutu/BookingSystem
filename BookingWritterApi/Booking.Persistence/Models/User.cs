using System;

namespace Booking.Persistence.Models
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }
}
