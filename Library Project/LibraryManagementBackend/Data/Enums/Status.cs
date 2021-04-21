using System.ComponentModel.DataAnnotations;

namespace LibraryManagementBackend.Data.Enums
{
  public enum Status
  {
    [Display(Name = "Waiting")]
    Waiting,
    [Display(Name = "Approved")]
    Approved,
    [Display(Name = "Rejected")]
    Rejected
  }
}
