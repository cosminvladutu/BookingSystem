using Booking.Contracts;
using Booking.Messages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Actions.Commands
{
    public class CreateBookingCommandHandler : INotificationHandler<CreateBookingCommandRequest>
    {
        private readonly IBookingRepository _repo;
        public CreateBookingCommandHandler(IBookingRepository repo)
        {
            _repo = repo;
        }
        public Task Handle(CreateBookingCommandRequest notification, CancellationToken cancellationToken)
        {
            var booking = Models.Booking.Create(notification);

            _repo.Save(booking);

            return Task.CompletedTask;
        }
    }
}
