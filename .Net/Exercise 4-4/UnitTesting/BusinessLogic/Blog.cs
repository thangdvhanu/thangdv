using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}