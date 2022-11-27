using DeliveryApp.Commons.Core;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Commons.Controllers;

[Route("[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    protected ActionResult HandleResult<T>(Result<T> result)
    {
        if (result == null) return NotFound();

        if (result.IsSuccess && result.Value != null) return Ok(result.Value);

        if (result.IsSuccess && result.Value == null) return NotFound();
        return BadRequest(result.Error);
    }
}