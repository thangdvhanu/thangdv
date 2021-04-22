using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagementBackend.Data.Enums;
using LibraryManagementBackend.Data.Message;
using LibraryManagementBackend.Models;
using LibraryManagementBackend.Models.Entity;
using LibraryManagementBackend.Repositoties;
using LibraryManagementBackend.Repositoties.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementBackend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RequestController : ControllerBase
  {

    private readonly IRequestRepository _repository;

    public RequestController(IRequestRepository repository)
    {
      _repository = repository;
    }

    [Authorize("Admin")]
    [HttpGet]
    public IActionResult Get()
    {
      IEnumerable<BorrowingRequest> requests = _repository.GetAll();
      if (requests != null)
      {
        return Ok(requests);
      }
      else
      {
        return BadRequest(Message.ErrorOccurredMessage);
      }
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetRequestsByUserId(int id)
    {
      IEnumerable<BorrowingRequest> requests = _repository.FilterByStatus(id);
      if (requests != null)
      {
        return Ok(requests);
      }
      else
      {
        return BadRequest(Message.IdNotFoundMessage);
      }
    }

    [Authorize]
    [HttpPost("{id}")]
    public IActionResult Post(int id, List<int> bookIds)
    {
      int result = _repository.Create(id, bookIds);
      switch (result)
      {
        case 0:
          return Ok();
        case 1: return BadRequest(Message.RequestBookError);
        case 2: return BadRequest(Message.MonthRequestError);
        default: return BadRequest(Message.ErrorOccurredMessage);
      }
    }

    [Authorize("Admin")]
    [HttpPost("{userId}/approve/{requestId}")]
    public IActionResult Approve(int userId, int requestId)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(Message.ErrorOccurredMessage);
      }
      else
      {
        BorrowingRequest request = _repository.GetById(requestId);
        if (request != null)
        {
          _repository.Approve(userId, request);
          return Ok(request);
        }
        else
        {
          return BadRequest(Message.IdNotFoundMessage);
        }
      }
    }

    [Authorize("Admin")]
    [HttpPost("{userId}/reject/{requestId}")]
    public IActionResult Reject(int userId, int requestId)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(Message.ErrorOccurredMessage);
      }
      else
      {
        BorrowingRequest request = _repository.GetById(requestId);
        if (request != null)
        {
          _repository.Reject(userId, request);
          return Ok(request);
        }
        else
        {
          return BadRequest(Message.IdNotFoundMessage);
        }
      }
    }
  }
}
