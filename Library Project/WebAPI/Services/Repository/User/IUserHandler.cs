using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.Models;

namespace WebAPI.Services
{
  public interface IUserHandler : IHandler<User>
  {

  }
}
