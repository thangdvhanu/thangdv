using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.Models;

namespace WebAPI.Services
{
  public interface IRepository<T>
  {
    IEnumerable<T> GetAll();
    T Get(int id);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
  }
}
