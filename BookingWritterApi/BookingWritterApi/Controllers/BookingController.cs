using BookingWritterApi.Infrastructure.ViewModels;
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
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingController"/> class (the class that contains all the actions
        /// that change a booking).
        /// </summary>
        public BookingController()
        {

        }
        /// <summary>
        /// Saves a new booking.
        /// </summary>
        /// <param name="vm">The booking view model, that contains the information regarding the booking that will be saved.</param>
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, type: typeof(ErrorViewModel))]
        public async Task Create([FromBody] BookingVm vm)
        {
        }
    }
}
