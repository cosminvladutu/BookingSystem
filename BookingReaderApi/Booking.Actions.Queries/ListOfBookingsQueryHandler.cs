using Booking.Messages.Queries;
using Booking.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Actions.Queries
{
    public class ListOfBookingsQueryHandler : IRequestHandler<ListOfBookingsQueryRequest, ListOfBookingsQueryResponse>
    {
        private readonly BookingDbContext _bookingContext;

        public ListOfBookingsQueryHandler(BookingDbContext bookingContext)
        {
            _bookingContext = bookingContext;
        }

        public async Task<ListOfBookingsQueryResponse> Handle(ListOfBookingsQueryRequest request, CancellationToken cancellationToken)
        {
            var bookingEntityList = _bookingContext.Booking.Where(s => s.UserId == request.UserId).ToList();
            if (!bookingEntityList.Any())
            {
                return null;
            }
            else
            {
                return new ListOfBookingsQueryResponse
                {
                    Active = bookingEntityList.Where(s => s.EndDate >= DateTime.Now)
                             .ToList()
                             .ConvertAll(BookingEntityToVM()),
                    History = bookingEntityList.Where(s => s.EndDate < DateTime.Now)
                             .ToList()
                             .ConvertAll(BookingEntityToVM())
                };
            }
        }

        private Converter<Persistence.Entities.Booking, BookingVm> BookingEntityToVM()
        {
            return s => new BookingVm
            {
                CreationDate = s.CreationDate,
                EndDate = s.EndDate,
                HotelId = s.HotelId,
                RoomId = s.RoomId,
                StartDate = s.StartDate
            };
        }
    }
}
