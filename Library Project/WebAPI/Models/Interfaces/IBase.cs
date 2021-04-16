using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
  public interface IBase
  {
    [Key]
    int Id { get; set; }
  }
}
