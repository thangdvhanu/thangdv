using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryManagementBackend.Data.Enums;

namespace LibraryManagementBackend.Models.Entity
{
    public class BorrowingRequest : BaseEntity
    {
        [Required]
        public Status Status { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [Required]
        public int RequestUserId { get; set; }
        public virtual User RequestUser { get; set; }

        public int? ApprovalUserId { get; set; }
        [NotMapped]
        public virtual User ApprovalUser { get; set; }

        public int? RejectUserId { get; set; }
        [NotMapped]
        public virtual User RejectUser { get; set; }

        public virtual ICollection<BorrowingRequestDetails> RequestDetails { get; set; }
    }
}
