using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services
{
  public class RequestDetailsHandler : IRequestDetailsHandler
  {
    private readonly DBContext _context;
    public RequestDetailsHandler(DBContext context)
    {
      _context = context;
    }
    public List<BorrowingRequestDetails> GetAll()
    {
      return _context.BorrowingRequestDetails.Include(c => c.Book).Include(b => b.Request).ToList();
    }
    public BorrowingRequestDetails GetById(int id)
    {
      return _context.BorrowingRequestDetails.FirstOrDefault(c => c.Id == id);
    }

    public int Create(BorrowingRequestDetails requestDetails)
    {
      _context.BorrowingRequestDetails.AddAsync(requestDetails);
      return _context.SaveChanges();
    }

    public int Update(BorrowingRequestDetails requestDetails)
    {
      var item = _context.BorrowingRequestDetails.FirstOrDefault(c => c.Id == requestDetails.Id);
      item.RequestId = requestDetails.RequestId;
      item.BookId = requestDetails.BookId;
      return _context.SaveChanges();
    }

    public void Delete(int id)
    {
      var item = _context.BorrowingRequestDetails.FirstOrDefault(c => c.Id == id);
      _context.BorrowingRequestDetails.Remove(item);
    }

  }
}
