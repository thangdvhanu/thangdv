using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services
{
  public class RequestHandler : IRequestHandler
  {
    private readonly DBContext _context;
    public RequestHandler(DBContext context)
    {
      _context = context;
    }
    public List<BorrowingRequest> GetAll()
    {
      return _context.BorrowingRequests.ToList();
    }

    public BorrowingRequest GetById(int id)
    {
      return _context.BorrowingRequests.FirstOrDefault(c => c.Id == id);
    }

    public int Create(BorrowingRequest request)
    {
      _context.BorrowingRequests.AddAsync(request);
      return _context.SaveChanges();
    }

    public int Update(BorrowingRequest request)
    {
      var item = _context.BorrowingRequests.FirstOrDefault(x => x.Id == request.Id);
      item.Status = request.Status;
      item.RejectUserId = request.RejectUserId;
      item.ApprovalUserId = request.ApprovalUserId;
      item.RequestUserId = request.RequestUserId;
      item.RequestDate = request.RequestDate;
      item.ReturnDate = request.ReturnDate;
      return _context.SaveChanges();
    }
    public void Delete(int id)
    {
      var category = _context.BorrowingRequests.FirstOrDefault(x => x.Id == id);
      _context.BorrowingRequests.Remove(category);
    }

  }
}
