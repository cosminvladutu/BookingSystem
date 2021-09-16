using Booking.Messages.Queries;
using BookingReaderApi.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BookingReaderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingController"/> class (the class that contains all the actions
        /// that change a booking).
        /// </summary>
        public BookingController()
        {

        }
        /// <summary>
        /// Gets all the active bookings.
        /// </summary>
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(ListOfBookingsQueryResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(ErrorViewModel))]

        public async Task<ListOfBookingsQueryResponse> List([FromRoute] Guid userId)
        {
            return null;
        }

        /// <summary>
        /// Get a specific booking.
        /// </summary>
        /// <param name="bookingId">Identifier for the booking.</param>
        /// <returns>The booking with the specified id.</returns>
        [HttpGet]
        [Route("{bookingId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(GetBookingQueryResponse))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(ErrorViewModel))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        public async Task<GetBookingQueryResponse> Get([FromRoute] Guid bookingId)
        {
            return null;
        }

        /// <summary>
        /// Get a specific booking.
        /// </summary>
        /// <param name="userId">Identifier for the user.</param>
        /// <returns>The booking history for the specified user.</returns>
        [HttpGet]
        [Route("{userId}/history")]


        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(GetBookingQueryResponse))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(ErrorViewModel))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        public async Task<GetBookingQueryResponse> GetHistoryForSpecificUser([FromRoute] Guid userId)
        {
            return null;
        }
    }
}
