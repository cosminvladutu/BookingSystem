using BaseUnitTests;
using Booking.Messages;
using BookingWritterApi.Controllers;
using BookingWritterApi.Infrastructure.ViewModels;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BookingWritterApi.Tests
{
    public class BookingControllerTests : BaseTest<BookingController>
    {
        private Mock<IMediator> _mediatorMock;
        private BookingVm _bookingViewModel;

        [Fact]
        public void When_CreateIsCalledAndMediatrIsNull_Expect_NullReferenceException()
        {
            // Arrange
            SystemUnderTest = new BookingController(null);

            // Act
            Func<Task<IActionResult>> result = () => SystemUnderTest.Create(_bookingViewModel);

            //Assert
            result.Should().ThrowAsync<NullReferenceException>();
        }

        [Fact]
        public void When_CreateIsCalledAndMediatrThrowsException_Expect_ExceptionWithExpectedMessage()
        {
            // Arrange
            var exceptionMessage = "Publish test Exception";
            _mediatorMock.Setup(mock => mock.Publish(It.IsAny<CreateBookingCommandRequest>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception(exceptionMessage));

            // Act
            Func<Task<IActionResult>> result = () => SystemUnderTest.Create(_bookingViewModel);

            //Assert
            result.Should().ThrowAsync<Exception>().WithMessage(exceptionMessage);
        }

        [Fact]
        public async Task When_CreateIsCalledWithNullViewModel_Expect_BadRequestResult()
        {
            // Arrange
            // Act
            var result = await SystemUnderTest.Create(null);

            //Assert
            result.Should().BeOfType<BadRequestResult>();
        }

        [Theory]
        [MemberData(nameof(InvalidVm))]
        public async Task When_CreateIsCalledWithInvalidViewModel_Expect_BadRequestResult(BookingVm vm)
        {
            // Arrange
            // Act
            var result = await SystemUnderTest.Create(vm);

            //Assert
            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task When_CreateIsCalled_Expect_MediatrSendIsCalledWithExpectedCommand()
        {
            // Arrange

            // Act
            await SystemUnderTest.Create(_bookingViewModel);

            //Assert
            _mediatorMock.Verify(mock => mock.Publish(It.Is<CreateBookingCommandRequest>(
                request => request.EndDate == _bookingViewModel.EndDate
                           && request.StartDate == _bookingViewModel.StartDate
                           && request.Id == _bookingViewModel.Id
                           && request.UserId == _bookingViewModel.UserId
                           && request.RoomId == _bookingViewModel.RoomId
                           && request.HotelId == _bookingViewModel.HotelId
                           ), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task When_CreateIsCalledWithValidViewModel_Expect_OkResult()
        {
            // Arrange
            // Act
            var result = await SystemUnderTest.Create(_bookingViewModel);
            //Assert
            result.Should().BeOfType<OkResult>();
        }


        public static IEnumerable<object[]> InvalidVm =>
           new List<object[]>
           {
                new object[] { new BookingVm() },
                new object[] {
                    new BookingVm
                        {
                            Id = Guid.Empty,
                            HotelId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F965"),
                            RoomId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F966"),
                            UserId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F967"),
                            EndDate = new DateTime(2022, 09, 20),
                            StartDate = new DateTime(2021, 09, 20),
                        } },
                 new object[] {
                    new BookingVm
                        {
                            Id = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F964"),
                            HotelId = Guid.Empty,
                            RoomId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F966"),
                            UserId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F967"),
                            EndDate = new DateTime(2022, 09, 20),
                            StartDate = new DateTime(2021, 09, 20),
                        } },

                  new object[] {
                    new BookingVm
                        {
                            Id = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F964"),
                            HotelId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F965"),
                            RoomId = Guid.Empty,
                            UserId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F967"),
                            EndDate = new DateTime(2022, 09, 20),
                            StartDate = new DateTime(2021, 09, 20),
                        } },
                   new object[] {
                    new BookingVm
                        {
                            Id = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F964"),
                            HotelId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F965"),
                            RoomId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F966"),
                            UserId = Guid.Empty,
                            EndDate = new DateTime(2022, 09, 20),
                            StartDate = new DateTime(2021, 09, 20),
                        } },
                     new object[] {
                    new BookingVm
                        {
                            Id = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F964"),
                            HotelId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F965"),
                            RoomId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F966"),
                            UserId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F967"),
                            EndDate = DateTime.MinValue,
                            StartDate = new DateTime(2021, 09, 20),
                        } },
                      new object[] {
                    new BookingVm
                        {
                            Id = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F964"),
                            HotelId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F965"),
                            RoomId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F966"),
                            UserId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F967"),
                            EndDate = new DateTime(2022, 09, 20),
                            StartDate = DateTime.MinValue,
                        } },
                  new object[] {
                    new BookingVm
                        {
                            Id = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F964"),
                            HotelId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F965"),
                            RoomId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F966"),
                            UserId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F967"),
                            EndDate = DateTime.MaxValue,
                            StartDate = new DateTime(2021, 09, 20),
                        } },
                   new object[] {
                    new BookingVm
                        {
                            Id = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F964"),
                            HotelId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F965"),
                            RoomId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F966"),
                            UserId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F967"),
                            EndDate = new DateTime(2022, 09, 20),
                            StartDate = DateTime.MaxValue,
                        } },
                    new object[] {
                    new BookingVm
                        {
                            Id = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F964"),
                            HotelId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F965"),
                            RoomId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F966"),
                            UserId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F967"),
                            EndDate = new DateTime(2020, 09, 20),
                            StartDate = new DateTime(2021, 09, 20),
                        } },
                     new object[] {
                    new BookingVm
                        {
                            Id = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F964"),
                            HotelId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F965"),
                            RoomId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F966"),
                            UserId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F967"),
                            EndDate = new DateTime(2021, 09, 20),
                            StartDate = new DateTime(2021, 09, 20),
                        } },
           };

        protected override void CreateSystemUnderTest()
        {
            _mediatorMock = MockRepository.Create<IMediator>();
            var httpContext = new DefaultHttpContext();
            SystemUnderTest = new BookingController(_mediatorMock.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = httpContext
                }
            };
        }

        protected override void SetupMocking()
        {
            _mediatorMock.Setup(mock => mock.Publish(It.IsAny<CreateBookingCommandRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
        }

        protected override void SetupData()
        {
            _bookingViewModel = new BookingVm
            {
                Id = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F964"),
                HotelId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F965"),
                RoomId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F966"),
                UserId = Guid.Parse("2900D866-69E8-41CB-A2D5-CDBF9E07F967"),
                EndDate = new DateTime(2022, 09, 20),
                StartDate = new DateTime(2021, 09, 20),
            };
        }
    }
}
