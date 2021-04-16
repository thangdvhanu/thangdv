using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
  public class Book : IBase
  {
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string BookTitle { get; set; }
    public string BookDescription { get; set; }
    [Required]
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public virtual ICollection<BorrowingRequestDetails> BorrowingRequestDetails { get; set; }
  }
}
