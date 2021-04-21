using System.Collections.Generic;
using LibraryManagementBackend.Data.Message;
using LibraryManagementBackend.Models.Entity;
using LibraryManagementBackend.Models.View;
using LibraryManagementBackend.Repositoties.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementBackend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoryController : ControllerBase
  {
    private readonly ICategoryRepository _repository;

    public CategoryController(ICategoryRepository repository)
    {
      _repository = repository;
    }

    [Authorize("Admin")]
    [HttpGet]
    public IActionResult Get()
    {
      IEnumerable<Category> categories = _repository.GetAll();
      if (categories != null)
      {
        return Ok(categories);
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
      Category category = _repository.GetById(id);
      if (category != null)
      {
        return Ok(category);
      }
      else
      {
        return BadRequest(Message.IdNotFoundMessage);
      }

    }

    [Authorize("Admin")]
    [HttpPost("")]
    public IActionResult Post(CategoryFromView category)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(Message.ErrorOccurredMessage);
      }
      else
      {
        _repository.Create(category);
        return Created("", category);
      }
    }

    [Authorize("Admin")]
    [HttpPut("{id}")]
    public IActionResult Put(CategoryFromView category, int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(Message.ErrorOccurredMessage);
      }
      else
      {
        Category _category = _repository.GetById(id);
        if (_category != null)
        {
          _repository.Update(_category, category);
          return Ok(_category);
        }
        else
        {
        return BadRequest(Message.IdNotFoundMessage);
        }
      }
    }

    [Authorize("Admin")]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      Category category = _repository.GetById(id);
      if (category != null)
      {
        _repository.Delete(category);
        return Ok(category);
      }
      else
      {
        return BadRequest(Message.IdNotFoundMessage);
      }
    }
  }
}
