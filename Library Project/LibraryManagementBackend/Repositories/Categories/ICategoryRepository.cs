using LibraryManagementBackend.Models.Entity;
using LibraryManagementBackend.Models.View;

namespace LibraryManagementBackend.Repositoties.Categories
{
  public interface ICategoryRepository : IRepository<Category>
  {
    void Create(CategoryFromView category);
    void Update(Category _category, CategoryFromView category);
  }
}
