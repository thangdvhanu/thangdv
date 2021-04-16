using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.Models;

namespace WebAPI.Services
{
  public interface IHandler<T> where T : class
  {
    List<T> GetAll();
    T GetById(int id);
    int Create(T entity);
    int Update(T entity);
    void Delete(int id);
  }
}
