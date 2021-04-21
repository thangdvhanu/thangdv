using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementBackend.Models.Entity
{
    public class Role : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
