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
        public async Task Handle(CreateBookingCommandRequest request, CancellationToken cancellationToken)
        {
            var booking = Models.Booking.Create(request);

            await _repo.Save(booking);
        }
    }
}
