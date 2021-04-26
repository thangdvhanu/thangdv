using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagementBackend.Data;
using LibraryManagementBackend.Data.Enums;
using LibraryManagementBackend.Models.Entity;

namespace LibraryManagementBackend.Repositoties.Requests
{
  public class RequestRepository : IRequestRepository
  {

    private readonly LibraryContext _context;

    public RequestRepository(LibraryContext context)
    {
      _context = context;
    }

    public int Create(int userId, int[] bookIds)
    {
      int borrowTimeInMonth = _context.BorrowingRequests.Count(
                                                                c =>
                                                                c.RequestUserId == userId &&
                                                                c.RequestDate.Month == DateTime.Now.Month &&
                                                                c.RequestDate.Year == DateTime.Now.Year
      );
      if (borrowTimeInMonth < 3)
      {
        if (bookIds.Count() <= 5)
        {
          BorrowingRequest request = new BorrowingRequest
          {
            RequestUserId = userId,
            RequestDate = DateTime.Now,
            Status = Status.Waiting
          };
          _context.BorrowingRequests.AddAsync(request);
          _context.SaveChanges();
          foreach (int item in bookIds)
          {
            BorrowingRequestDetails requestDetails = new BorrowingRequestDetails
            {
              RequestId = request.Id,
              BookId = item
            };
            _context.BorrowingRequestDetails.AddAsync(requestDetails);
          }
          _context.SaveChanges();
          return 0;
        }
        else
        {
          return 1;
        }
      }
      else
      {
        return 2;
      }
    }

    public IEnumerable<BorrowingRequest> GetAll()
    {
      return _context.BorrowingRequests.AsEnumerable();
    }

    public BorrowingRequest GetById(int id)
    {
      return _context.BorrowingRequests.SingleOrDefault(s => s.Id == id);
    }

    public void Approve(int userId, BorrowingRequest request)
    {
      request.Status = Status.Approved;
      request.UpdateDate = DateTime.Now;
      request.ApprovalUserId = userId;
      _context.SaveChanges();
    }

    public void Reject(int userId, BorrowingRequest request)
    {
      request.Status = Status.Rejected;
      request.UpdateDate = DateTime.Now;
      request.RejectUserId = userId;
      _context.SaveChanges();
    }

    public IEnumerable<BorrowingRequest> FilterByStatus(int userId)
    {
      return _context.BorrowingRequests.Where(c => c.RequestUserId == userId).OrderBy(c => c.Status);
    }

    public void Update(BorrowingRequest _entity, BorrowingRequest entity)
    {
      throw new System.NotImplementedException();
    }

    public void Create(BorrowingRequest entity)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(BorrowingRequest entity)
    {
      throw new System.NotImplementedException();
    }

  }
}
