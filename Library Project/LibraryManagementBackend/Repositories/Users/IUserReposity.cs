using LibraryManagementBackend.Models.Entity;
using LibraryManagementBackend.Models.View;

namespace LibraryManagementBackend.Repositoties.Users
{
  public interface IUserRepository : IRepository<User>
  {
    User FindUser(string userName, string passWord);
    void Create(UserFromView user);
    void Update(User _user, UserForEdit user);
  }
}
