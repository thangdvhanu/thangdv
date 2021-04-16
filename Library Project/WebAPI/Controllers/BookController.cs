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
  public class BookController : ControllerBase
  {
    private readonly IBookHandler _bookHandler;
    public BookController(IBookHandler bookHandler)
    {
      _bookHandler = bookHandler;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get()
    {
      return _bookHandler.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Book> Get(int id)
    {
      return _bookHandler.GetById(id);
    }

    [HttpPost]
    public void Post(Book book)
    {
      _bookHandler.Create(book);
    }

    [HttpPut("{id}")]
    public void Put(Book book)
    {
      _bookHandler.Update(book);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      _bookHandler.Delete(id);
    }
  }
}
