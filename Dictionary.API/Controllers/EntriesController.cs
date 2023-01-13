using Dictionary.Application.DTOs;
using Dictionary.Application.Interfaces.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FcApp.API.Controllers;

[ApiController]
public class EntriesController : ControllerBase
{
  //[Authorize]
  [HttpGet("/entries/en")]
  public IActionResult GetList(
    [FromServices] IEntriesGetListHandler handler,
    [FromQuery] string search = "",
    [FromQuery] int limit = 5,
    [FromQuery] int page = 1
    )
  {
    try
    {
      var response = handler.Handler(new EntriesRequestDTO(search, limit, page));
      return Ok(response);
    }
    catch (Exception ex)
    {
      return BadRequest(new { message = ex.Message });
    }
  }
}
