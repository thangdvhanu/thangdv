using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services
{
  public class UserHandler : IUserHandler
  {
    private readonly DBContext _context;

    public UserHandler(DBContext context)
    {
      _context = context;
    }
    public List<User> GetAll()
    {
      return _context.Users.Include(c => c.BookBorrowingRequests).ToList();
    }

    public User GetById(int id)
    {
      return _context.Users.FirstOrDefault(c => c.Id == id);
    }

    public int Create(User user)
    {
      _context.Users.AddAsync(user);
      return _context.SaveChanges();
    }

    public int Update(User user)
    {
      var item = _context.Users.FirstOrDefault(c => c.Id == user.Id);
      item.Username = user.Username;
      item.Password = user.Password;
      item.Role = user.Role;
      return _context.SaveChanges();
    }

    public void Delete(int id)
    {
      var item = _context.Users.FirstOrDefault(c => c.Id == id);
      _context.Users.Remove(item);
    }

  }
}
