using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BusinessObject.Models
{
    public partial class Account
    {
        public Account()
        {
            Comments = new HashSet<Comment>();
            Orders = new HashSet<Order>();
        }

       
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
