using System.Collections.Generic;
using System.Linq;
using LibraryManagementBackend.Data;
using LibraryManagementBackend.Models.Entity;
using LibraryManagementBackend.Models.View;

namespace LibraryManagementBackend.Repositoties.Categories
{
  public class CategoryRepository : ICategoryRepository
  {

    private readonly LibraryContext _context;

    public CategoryRepository(LibraryContext context)
    {
      _context = context;
    }

    public void Create(CategoryFromView category)
    {
      _context.Categories.AddAsync(new Category
      {
        Name = category.Name
      });
      _context.SaveChanges();
    }

    public void Delete(Category category)
    {
      _context.Categories.Remove(category);
      _context.SaveChanges();
    }

    public IEnumerable<Category> GetAll()
    {
      return _context.Categories.AsEnumerable();
    }

    public Category GetById(int id)
    {
      return _context.Categories.SingleOrDefault(s => s.Id == id);
    }

    public void Update(Category _category, CategoryFromView category)
    {
      _category.Name = category.Name;
      _context.SaveChanges();
    }

    public void Update(Category _entity, Category entity)
    {
      throw new System.NotImplementedException();
    }

    public void Create(Category entity)
    {
      throw new System.NotImplementedException();
    }
  }
}
