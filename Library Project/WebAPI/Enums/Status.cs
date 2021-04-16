using System.ComponentModel.DataAnnotations;

namespace WebAPI.Enums
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
