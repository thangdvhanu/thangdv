using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementBackend.Models.Entity
{
  public class User : BaseEntity
  {
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
    public virtual ICollection<BorrowingRequest> Requests { get; set; }
  }
}
// sepreate entity model vs model view
