using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services
{
  public class BookHandler : IBookHandler
  {

    private DBContext _context;

    public BookHandler(DBContext context)
    {
      _context = context;
    }

    public List<Book> GetAll()
    {
      return _context.Books.Include(b => b.Category).ToList();
    }

    public Book GetById(int id)
    {
      return _context.Books.FirstOrDefault(c => c.Id == id);
    }

    public int Create(Book book)
    {
      _context.Books.AddAsync(book);
      return _context.SaveChanges();
    }

    public int Update(Book book)
    {
      var item = _context.Books.FirstOrDefault(x => x.Id == book.Id);
      item.BookTitle = book.BookTitle;
      item.BookDescription = book.BookDescription;
      item.CategoryId = book.CategoryId;

      return _context.SaveChanges();
    }

    public void Delete(int id)
    {
      var book = _context.Books.FirstOrDefault(x => x.Id == id);
      _context.Books.Remove(book);
    }

  }

}
