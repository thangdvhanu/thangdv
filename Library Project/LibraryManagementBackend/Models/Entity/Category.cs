using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementBackend.Models.Entity
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
