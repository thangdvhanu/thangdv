using System.Collections.Generic;
using LibraryManagementBackend.Data.Message;
using LibraryManagementBackend.Models.Entity;
using LibraryManagementBackend.Models.View;
using LibraryManagementBackend.Repositoties.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementBackend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BookController : ControllerBase
  {

    private readonly IBookRepository _repository;

    public BookController(IBookRepository repository)
    {
      _repository = repository;
    }


    [Authorize("Admin")]
    [HttpGet]
    public IActionResult Get()
    {
      IEnumerable<Book> books = _repository.GetAll();
      if (books != null)
      {
        return Ok(books);
      }
      else
      {
        return BadRequest(Message.ErrorOccurredMessage);
      }
    }


    [Authorize("Admin")]
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      Book book = _repository.GetById(id);
      if (book != null)
      {
        return Ok(book);
      }
      else
      {
        return BadRequest(Message.IdNotFoundMessage);
      }
    }

    [Authorize("Admin")]
    [HttpPost]
    public IActionResult Post(BookFromView book)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(Message.ErrorOccurredMessage);
      }
      else
      {
        _repository.Create(book);
        return Created("", book);
      }
    }

    [Authorize("Admin")]
    [HttpPut("{id}")]
    public IActionResult Put(int id, BookFromView book)
    {
      Book _book = _repository.GetById(id);
      if (_book != null)
      {
        _repository.Update(_book, book);
        return Ok(_book);
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
      Book book = _repository.GetById(id);
      if (book != null)
      {
        _repository.Delete(book);
        return Ok(book);
      }
      else
      {
        return BadRequest(Message.IdNotFoundMessage);
      }
    }
  }
}
