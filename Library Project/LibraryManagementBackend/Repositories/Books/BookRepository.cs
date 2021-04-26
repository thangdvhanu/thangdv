using System.Collections.Generic;
using System.Linq;
using LibraryManagementBackend.Data;
using LibraryManagementBackend.Models.Entity;
using LibraryManagementBackend.Models.View;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementBackend.Repositoties.Books
{
  public class BookRepository : IBookRepository
  {
    private readonly LibraryContext _context;

    public BookRepository(LibraryContext context)
    {
      _context = context;
    }

    public void Create(BookFromView book)
    {
      _context.Books.AddAsync(new Book
      {
        Title = book.Title,
        ShortContent = book.ShortContent,
        Url = book.Url,
        CategoryId = book.CategoryId
      });
      _context.SaveChanges();
    }

    public void Delete(Book book)
    {
      _context.Books.Remove(book);
      _context.SaveChanges();
    }

    public IEnumerable<Book> GetAll()
    {
      return _context.Books.AsEnumerable();
    }

    public Book GetById(int id)
    {
      return _context.Books.SingleOrDefault(s => s.Id == id);
    }

    public void Update(Book _book, BookFromView book)
    {
      _book.Title = book.Title;
      _book.ShortContent = book.ShortContent;
      _book.Url = book.Url;
      _book.CategoryId = book.CategoryId;
      _context.SaveChanges();
    }

    public void Create(Book entity)
    {
      throw new System.NotImplementedException();
    }

    public void Update(Book _entity, Book entity)
    {
      throw new System.NotImplementedException();
    }
  }
}
