using MediatR;
using System;

namespace Booking.Messages.Queries
{
    public class ListOfBookingsQueryRequest : IRequest<ListOfBookingsQueryResponse>
    {
        public ListOfBookingsQueryRequest(Guid userId)
        {
            Validate(userId);
            UserId = userId;
        }

        public Guid UserId { get; set; }

        private void Validate(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentException("UserId provided is empty");
            }
        }
    }
}
