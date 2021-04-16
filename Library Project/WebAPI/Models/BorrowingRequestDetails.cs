using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
  public class BorrowingRequestDetails : IBase
  {
    public int Id { get; set; }
    public int RequestId { get; set; }
    public virtual BorrowingRequest Request { get; set; }
    public int BookId { get; set; }
    public virtual Book Book { get; set; }
  }
}
