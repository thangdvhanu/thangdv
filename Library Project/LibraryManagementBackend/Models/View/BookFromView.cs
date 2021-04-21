using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementBackend.Models.View
{
    public class BookFromView
    {
        public string Title { get; set; }
        public string ShortContent { get; set; }
        public string Url { get; set; }
        public int CategoryId { get; set; }
    }
}
