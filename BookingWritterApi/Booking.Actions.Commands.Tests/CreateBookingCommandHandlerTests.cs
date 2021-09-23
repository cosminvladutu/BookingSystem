using BaseUnitTests;
using Booking.Contracts;
using Booking.Messages;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Booking.Actions.Commands.Tests
{
    public class CreateBookingCommandHandlerTests : BaseTest<CreateBookingCommandHandler>
    {
        private Mock<IBookingRepository> _bookingRepoMock;
        private CreateBookingCommandRequest _commandRequest;


        protected override void CreateSystemUnderTest()
        {
            _bookingRepoMock = MockRepository.Create<IBookingRepository>();
            SystemUnderTest = new CreateBookingCommandHandler(_bookingRepoMock.Object);
        }

        protected override void SetupData()
        {
            _commandRequest = new CreateBookingCommandRequest 
            {
                Id = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F964"),
                HotelId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F965"),
                RoomId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F966"),
                UserId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F967"),
                EndDate = new DateTime(2022, 09, 20),
                StartDate = new DateTime(2021, 09, 20),
            };
        }

        protected override void SetupMocking()
        {
            _bookingRepoMock.Setup(x => x.Save(It.IsAny<Models.Booking>()))
                .Returns(Task.CompletedTask);
        }
    }
}
