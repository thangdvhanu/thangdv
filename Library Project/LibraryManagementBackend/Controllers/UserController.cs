using System.Collections.Generic;
using LibraryManagementBackend.Data.Message;
using LibraryManagementBackend.Models.Entity;
using LibraryManagementBackend.Models.View;
using LibraryManagementBackend.Repositoties.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementBackend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {

    private readonly IUserRepository _repository;

    public UserController(IUserRepository repository)
    {
      _repository = repository;
    }

    [Authorize("Admin")]
    [HttpGet]
    public IActionResult Get()
    {
      IEnumerable<User> users = _repository.GetAll();
      if (users != null)
      {
        return Ok(users);
      }
      else
      {
        return BadRequest(Message.IdNotFoundMessage);
      }
    }

    [Authorize("Admin")]
    [HttpGet("{id}")]
    public ActionResult Get(int id)
    {
      User user = _repository.GetById(id);
      if (user != null)
      {
        return Ok(user);
      }
      return BadRequest(Message.IdNotFoundMessage);
    }

    [Authorize("Admin")]
    [HttpPost("")]
    public IActionResult Post(UserFromView user)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(Message.ErrorOccurredMessage);
      }
      else
      {
        _repository.Create(user);
        return Created("", user);
      }
    }

    [Authorize("Admin")]
    [HttpPut("{id}")]
    public IActionResult Put(int id, UserForEdit user)
    {
      User _user = _repository.GetById(id);
      if (user != null)
      {
        _repository.Update(_user, user);
        return Ok(_user);
      }
      else
      {
        return BadRequest(Message.IdNotFoundMessage);
      }
    }

    [Authorize("Admin")]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      User user = _repository.GetById(id);
      if (user != null)
      {
        _repository.Delete(user);
        return Ok(user);
      }
      else
      {
        return BadRequest(Message.IdNotFoundMessage);
      }
    }
  }
}
