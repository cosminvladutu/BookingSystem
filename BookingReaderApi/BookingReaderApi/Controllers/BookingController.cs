using Booking.Messages.Queries;
using BookingReaderApi.Infrastructure.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BookingReaderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : BaseController
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingController"/> class (the class that contains all the actions
        /// that change a booking).
        /// </summary>
        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets bookings based on an user and on the type of bookings the query is made.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>A list of bookings</returns>
        [HttpGet]
        [Route("{userId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(ListOfBookingsQueryResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.NoContent)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(ErrorViewModel))]

        public async Task<ListOfBookingsQueryResponse> List([FromRoute] Guid userId)
        {
            var result= await _mediator.Send(new ListOfBookingsQueryRequest(userId));

            return ProcessResponse(result);
        }
    }
}
