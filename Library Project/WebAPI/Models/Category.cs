using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
  public class Category:IBase
  {
    public int Id { get ; set ; }
    [Required]
    [MaxLength(50)]
    public string CategoryName { get; set; }
    public virtual ICollection<Book> Books { get; set; }
  }
}
