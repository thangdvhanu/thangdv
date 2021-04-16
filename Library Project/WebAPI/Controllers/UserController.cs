using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {

    private readonly IUserHandler _userHandler;

    public UserController(IUserHandler userHandler)
    {
      _userHandler = userHandler;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
      return _userHandler.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
      return _userHandler.GetById(id);
    }

    [HttpPost]
    public void Post(User user)
    {
      _userHandler.Create(user);
    }

    [HttpPut("{id}")]
    public void Put(User user)
    {
      _userHandler.Update(user);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      _userHandler.Delete(id);
    }
  }
}
