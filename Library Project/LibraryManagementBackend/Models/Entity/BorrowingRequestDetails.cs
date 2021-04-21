using System.ComponentModel.DataAnnotations;

namespace LibraryManagementBackend.Models.Entity
{
  public class BorrowingRequestDetails : BaseEntity
  {
    [Required]
    public int RequestId { get; set; }
    public virtual BorrowingRequest Request { get; set; }
    [Required]
    public int BookId { get; set; }
    public virtual Book Book { get; set; }
  }
}
