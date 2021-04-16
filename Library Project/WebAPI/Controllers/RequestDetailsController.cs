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
  public class RequestDetailsController : ControllerBase
  {

    private readonly IRequestDetailsHandler _requestDetailsHandler;

    public RequestDetailsController(IRequestDetailsHandler requestDetailsHandler)
    {
      _requestDetailsHandler = requestDetailsHandler;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BorrowingRequestDetails>> Get()
    {
      return _requestDetailsHandler.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<BorrowingRequestDetails> Get(int id)
    {
      return _requestDetailsHandler.GetById(id);
    }

    [HttpPost]
    public void Post(BorrowingRequestDetails requestDetails)
    {
      _requestDetailsHandler.Create(requestDetails);
    }

    [HttpPut("{id}")]
    public void Put(BorrowingRequestDetails requestDetails)
    {
      _requestDetailsHandler.Update(requestDetails);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      _requestDetailsHandler.Delete(id);
    }
  }
}
