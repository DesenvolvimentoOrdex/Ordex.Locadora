using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ordex.LocadoraApi.Controllers
{
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
        protected IActionResult Success(object data)
        {
            return Ok(new { success = true, data });
        }

        protected IActionResult Created(Uri uri, object data)
        {
            return StatusCode(201, new { success = true, data });
        }

        protected IActionResult NoContent()
        {
            return StatusCode(204);
        }

        protected IActionResult BadRequest(string message)
        {
            return StatusCode(400, new { success = false, error = message });
        }

        protected IActionResult NotFound(string message)
        {
            return StatusCode(404, new { success = false, error = message });
        }

        protected IActionResult InternalServerError(string message)
        {
            return StatusCode(500, new { success = false, error = message });
        }
    }
}
