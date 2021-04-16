using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
  public enum Role
  {

    [Display(Name = "Admin")]
    Admin,
    [Display(Name = "Member")]
    Member
  }
}
