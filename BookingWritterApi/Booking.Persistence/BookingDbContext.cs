using Microsoft.EntityFrameworkCore;
using System;

namespace Booking.Persistence
{
    public class BookingDbContext : DbContext
    {
        public DbSet<Entities.Booking> Booking { get; set; }
        public DbSet<Entities.Hotel> Hotel { get; set; }
        public DbSet<Entities.Room> Room { get; set; }
        public DbSet<Entities.User> User { get; set; }

        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Hotel>().HasMany(s => s.RoomList).WithOne(s => s.Hotel).HasForeignKey(s => s.HotelId);
            SeedDb(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void SeedDb(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.User>().HasData(
                new Entities.User
                {
                    Email = "test@testing.com",
                    LastName = "testLastName",
                    FirstName = "testFirstName",
                    PhoneNo = "074123456789",
                    Username = "testUser",
                    Id = Guid.NewGuid()
                });
            modelBuilder.Entity<Entities.User>().HasData(
               new Entities.User
               {
                   Email = "test2@testing.com",
                   LastName = "test2LastName",
                   FirstName = "test2FirstName",
                   PhoneNo = "074123456712",
                   Username = "testUser2",
                   Id = Guid.NewGuid()
               });
            var hotel1Id = Guid.Parse("e8457c0d-18d4-420b-ad23-e032dbe146ce");
            var hotel2Id = Guid.Parse("7ba931e3-9f95-489f-8ae4-ed1fda8e0365");
            var room1Id = Guid.Parse("c3988c86-d83b-47ae-bd72-d503e7eafd0b");
            var room2Id = Guid.Parse("0087a0b6-a808-4a02-b038-5b96fcc1f6bf");
            var room3Id = Guid.Parse("d274196d-96f9-437e-98ea-0f312b9dbd78");

            var firstRoom = new Entities.Room
            {
                Id = room1Id,
                Description = "testRoomDescr",
                HotelId = hotel1Id
            };
            var secondRoom = new Entities.Room
            {
                Id = room2Id,
                Description = "testRoomDescr",
                HotelId = hotel2Id
            };
            var thirdRoom = new Entities.Room
            {
                Id = room3Id,
                Description = "testRoomDescr",
                HotelId = hotel2Id
            };

            modelBuilder.Entity<Entities.Hotel>(b =>
            {
                b.HasData(new Entities.Hotel
                {
                    Email = "test@testing.com",
                    Address = "testAddress",
                    Description = "testDescription",
                    PhoneNo = "074123456789",
                    Name = "testHotelName",
                    Id = hotel1Id,
                });
            });
            modelBuilder.Entity<Entities.Hotel>(b =>
            {
                b.HasData(new Entities.Hotel
                {
                    Email = "test2@testing.com",
                    Address = "testAddressHotel2",
                    Description = "testDescriptionHotel2",
                    PhoneNo = "074123456123",
                    Name = "testHotelName2",
                    Id = hotel2Id,
                });
            });
            modelBuilder.Entity<Entities.Room>().HasData(
                firstRoom);
            modelBuilder.Entity<Entities.Room>().HasData(
                secondRoom);
            modelBuilder.Entity<Entities.Room>().HasData(
                thirdRoom);
        }
    }
}
