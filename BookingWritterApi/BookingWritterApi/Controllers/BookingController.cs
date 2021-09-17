using BookingWritterApi.Infrastructure.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Threading.Tasks;

namespace BookingWritterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
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
        /// Saves a new booking.
        /// </summary>
        /// <param name="vm">The booking view model, that contains the information regarding the booking that will be saved.</param>
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(ErrorViewModel))]
        public async Task<IActionResult> Create([FromBody] BookingVm vm)
        {
            if (vm == null || !vm.IsValid())
            {
                return BadRequest();
            }

           var result = await _mediator.Send(vm.ToCreateCommand());

            Response.StatusCode = 201;
            return result;
        }
    }
}
