using System.ComponentModel.DataAnnotations;

namespace LibraryManagementBackend.Models.Entity
{
  public class BaseEntity
  {
    [Key]
    public int Id { get; set; }
  }
}
