using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
  public class User : IBase
  {
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public Role Role { get; set; }
    public virtual ICollection<BorrowingRequest> BookBorrowingRequests { get; set; }
  }
}
