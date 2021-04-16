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
  public class RequestController : ControllerBase
  {

    private readonly IRequestHandler _requestHandler;

    public RequestController(IRequestHandler requestHandler)
    {
      _requestHandler = requestHandler;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BorrowingRequest>> Get()
    {
      return _requestHandler.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<BorrowingRequest> Get(int id)
    {
      return _requestHandler.GetById(id);
    }

    [HttpPost]
    public void Post(BorrowingRequest request)
    {
      _requestHandler.Create(request);
    }

    [HttpPut("{id}")]
    public void Put(BorrowingRequest request)
    {
      _requestHandler.Update(request);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      _requestHandler.Delete(id);
    }
  }
}
