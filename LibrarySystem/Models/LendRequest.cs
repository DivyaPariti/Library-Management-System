using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace LibrarySystem.Models
{
    public partial class LendRequest
    {
        [Key]
        public int LendId { get; set; }

        [ForeignKey("BookId")]
        public int? BookId { get; set; }

        [Display(Name = "Lend Date")]
        public DateTime? LendDate { get; set; }

        [Display(Name = "Return Date")]
        public DateTime? ReturnDate { get; set; }

        [Display(Name = "Fine Amount")]
        public double? FineAmount { get; set; }

        [ForeignKey("UserId")]
        public int? UserId { get; set; }

        [Display(Name = "Status")]
        public string ReqStatus { get; set; }

        public virtual BooksInfo Book { get; set; }
        public virtual AccountsInfo User { get; set; }
    }
}
