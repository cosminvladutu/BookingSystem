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
        /// Gets bookings based on an user and on the type of bookings the query is made.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="listType">The type of bookings: 1 for all bookings, 2 for the inactive ones or 3 for the active ones.</param>
        /// <returns>A list of bookings</returns>
        [HttpGet]
        [Route("{userId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(ListOfBookingsQueryResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(ErrorViewModel))]

        public async Task<ListOfBookingsQueryResponse> List([FromRoute] Guid userId, [FromQuery]ListType listType)
        {
            return null;
        }
    }
}
