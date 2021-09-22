using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingReaderApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected T ProcessResponse<T>(T response) where T : class
        {
            if (response is null)
            {
                Response.StatusCode = (int)HttpStatusCode.NoContent;
                return response;
            }

            return response;
        }
    }
}
