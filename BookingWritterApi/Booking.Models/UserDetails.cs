using System;

namespace Booking.Models
{
    public class UserDetails
    {
        public Guid Id { get; private set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }

        //public UserDetails(Guid id, string username, string firstName, string lastName, string email, string phoneNo)
        //{
        //    Id = id;
        //    Username = username;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Email = email;
        //    PhoneNo = phoneNo;
        //}
    }
}
