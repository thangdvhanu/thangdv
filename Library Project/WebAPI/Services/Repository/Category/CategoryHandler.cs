using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services
{
  public class CategoryHandler : ICategoryHandler
  {
    private DBContext _context;
    public CategoryHandler(DBContext context)
    {
      _context = context;
    }
    public List<Category> GetAll()
    {
      return _context.Categories.Include(c => c.Books).ToList();
    }

    public int Create(Category category)
    {
      _context.Categories.AddAsync(category);
      return _context.SaveChanges();
    }

    public int Update(Category category)
    {
      var item = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
      item.CategoryName = category.CategoryName;

      return _context.SaveChanges();
    }
    public void Delete(int id)
    {
      var category = _context.Categories.FirstOrDefault(x => x.Id == id);
      _context.Categories.Remove(category);
    }

    public Category GetById(int id)
    {
      return _context.Categories.FirstOrDefault(c => c.Id == id);
    }
  }

}
