using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LibrarySystem.Models
{
    public partial class AccountsInfo
    {
        public AccountsInfo()
        {
            LendRequests = new HashSet<LendRequest>();
        }

        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }

        [Display(Name = "Password")]
        public string Psd { get; set; }

        [Display(Name = "Account Type")]
        public string AccountType { get; set; }

        public virtual ICollection<LendRequest> LendRequests { get; set; }
    }
}
