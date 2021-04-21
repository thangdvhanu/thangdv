using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementBackend.Models.Entity
{
  public class Book : BaseEntity
  {
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    public string ShortContent { get; set; }
    public string Url { get; set; }
    [Required]
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public virtual ICollection<BorrowingRequestDetails> RequestDetails { get; set; }
  }
}
