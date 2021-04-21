using LibraryManagementBackend.Models.Entity;
using LibraryManagementBackend.Models.View;

namespace LibraryManagementBackend.Repositoties.Books
{
  public interface IBookRepository : IRepository<Book>
  {
    void Create(BookFromView book);
    void Update(Book _book, BookFromView book);
  }
}
