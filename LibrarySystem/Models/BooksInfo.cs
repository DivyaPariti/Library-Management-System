using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LibrarySystem.Models
{
    public partial class BooksInfo
    {
        public BooksInfo()
        {
            LendRequests = new HashSet<LendRequest>();
        }

        [Key]
        public int BookId { get; set; }

        [Display(Name = "Title")]
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        [Display(Name = "Number of Copies")]
        public int? NumberofCopies { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<LendRequest> LendRequests { get; set; }
    }
}
