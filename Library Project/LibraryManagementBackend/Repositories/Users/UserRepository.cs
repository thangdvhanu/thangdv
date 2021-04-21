using System.Collections.Generic;
using System.Linq;
using LibraryManagementBackend.Data;
using LibraryManagementBackend.Models.Entity;
using LibraryManagementBackend.Models.View;

namespace LibraryManagementBackend.Repositoties.Users
{
  public class UserRepository : IUserRepository
  {

    private readonly LibraryContext _context;

    public UserRepository(LibraryContext context)
    {
      _context = context;
    }

    public void Create(UserFromView user)
    {
      User _user = new User
      {
        Username = user.Username,
        Password = user.Password,
        RoleId = 2
      };
      _context.Users.AddAsync(_user);
      _context.SaveChanges();
    }

    public void Delete(User user)
    {
      _context.Users.Remove(user);
      _context.SaveChanges();
    }

    public IEnumerable<User> GetAll()
    {
      return _context.Users.AsEnumerable();
    }

    public User GetById(int id)
    {
      return _context.Users.SingleOrDefault(s => s.Id == id);
    }

    public void Update(User _user, UserForEdit user)
    {
      _user.Username = user.Username;
      _user.Password = user.Password;
      _user.RoleId = user.RoleId;
      _context.SaveChanges();
    }

    public User FindUser(string userName, string passWord)
    {
      return _context.Users.FirstOrDefault(c => c.Username == userName && c.Password == passWord);
    }

    public void Create(User entity)
    {
      throw new System.NotImplementedException();
    }

    public void Update(User _entity, User entity)
    {
      throw new System.NotImplementedException();
    }
  }
}
