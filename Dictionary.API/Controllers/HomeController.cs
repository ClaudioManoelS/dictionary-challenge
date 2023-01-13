using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FcApp.API.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
  [HttpGet("/")]
  public dynamic Home()
  {
    return new { message = "Fullstack Challenge 🏅 - Dictionary" };
  }
}
