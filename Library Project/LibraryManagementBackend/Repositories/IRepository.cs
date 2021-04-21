using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LibraryManagementBackend.Data;

namespace LibraryManagementBackend.Repositoties
{
  public interface IRepository<T>
  {
    IEnumerable<T> GetAll();

    T GetById(int id);

    void Create(T entity);

    void Update(T _entity, T entity);

    void Delete(T entity);

  }
}
