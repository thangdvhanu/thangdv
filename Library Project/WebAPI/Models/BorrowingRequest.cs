using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Enums;

namespace WebAPI.Models
{
  public class BorrowingRequest : IBase
  {
    public int Id { get; set; }
    [Required]
    public Status Status { get; set; }
    [Required]
    public DateTime RequestDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    [Required]
    public int RequestUserId { get; set; }
    public virtual User RequestUser { get; set; }

    public int? ApprovalUserId { get; set; }
    [NotMapped]
    public virtual User ApprovalUser { get; set; }

    public int? RejectUserId { get; set; }
    [NotMapped]
    public virtual User RejectUser { get; set; }
    public virtual ICollection<BorrowingRequestDetails> BorrowingRequestDetails { get; set; }
  }
}
