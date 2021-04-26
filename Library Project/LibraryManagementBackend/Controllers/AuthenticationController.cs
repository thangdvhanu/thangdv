using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using LibraryManagementBackend.Data.Message;
using LibraryManagementBackend.Models.Entity;
using LibraryManagementBackend.Models.View;
using LibraryManagementBackend.Repositoties.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementBackend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthenticationController : ControllerBase
  {
    private readonly IUserRepository _repository;

    public AuthenticationController(IUserRepository repository)
    {
      _repository = repository;
    }
    [HttpGet("/loginFail")]
    public IActionResult Unauthorize()
    {
      return Unauthorized();
    }

    [HttpGet("/accessDenied")]
    public IActionResult AccessDenied()
    {
      return StatusCode(403);
    }

    [HttpPost("/login")]
    public async Task<IActionResult> LoginAsync(UserFromView user)
    {
      User _user = _repository.FindUser(user.Username, user.Password);

      if (_user != null)
      {

        List<Claim> claims = new List<Claim>
        {
          new Claim(ClaimTypes.Name, _user.Username),
          new Claim("Password", _user.Password),
          new Claim(ClaimTypes.Role, _user.Role.Name)
        };

        ClaimsIdentity claimsIdentity = new ClaimsIdentity(
          claims, CookieAuthenticationDefaults.AuthenticationScheme);

        AuthenticationProperties authenticationProperties = new AuthenticationProperties
        {
          AllowRefresh = true,
          ExpiresUtc = DateTimeOffset.Now.AddHours(3),
          IsPersistent = true,
        };

        await HttpContext.SignInAsync(
          CookieAuthenticationDefaults.AuthenticationScheme,
          new ClaimsPrincipal(claimsIdentity),
          authenticationProperties);

        return Ok(_user);
      }
      else
      {
        return BadRequest(Message.InvalidLoginMessage);
      }

    }

    [Authorize]
    [HttpPost("/logout")]
    public async Task<IActionResult> LogoutAsync()
    {
      await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
      return Ok(Message.LogoutMess);
    }

  }
}
