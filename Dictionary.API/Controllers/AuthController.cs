using Dictionary.Application.DTOs;
using Dictionary.Application.Interfaces.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FcApp.API.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
  //[Authorize]
  [HttpPost("/auth/signup")]
  public IActionResult SignUp([FromServices] IUserSignUpHandler handler, SignUpRequestDTO request)
  {
    try
    {
      var response = handler.Handler(request);
      return Ok(response);
    }
    catch (Exception ex)
    {
      return BadRequest(new { message = ex.Message });
    }
  }

  [HttpPost("/auth/signin")]
  public IActionResult SignIn([FromServices] IUserSignInHandler handler, SignInRequestDTO request)
  {
    try
    {
      var response = handler.Handler(request);
      return Ok(response);
    }
    catch (Exception ex)
    {
      return BadRequest(new { message = ex.Message });
    }
  }
}
