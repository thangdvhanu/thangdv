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
  public class CategoryController : ControllerBase
  {
    private readonly ICategoryHandler _categoryHandler;
    public CategoryController(ICategoryHandler categoryHandler)
    {
      _categoryHandler = categoryHandler;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Category>> Get()
    {
      return _categoryHandler.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Category> Get(int id)
    {
      return _categoryHandler.GetById(id);
    }

    [HttpPost]
    public void Post(Category category)
    {
      _categoryHandler.Create(category);
    }

    [HttpPut("{id}")]
    public void Put(Category category)
    {
      _categoryHandler.Update(category);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      _categoryHandler.Delete(id);
    }
  }
}
