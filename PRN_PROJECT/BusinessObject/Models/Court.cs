using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Models
{
    public partial class Court
    {
        public Court()
        {
            Comments = new HashSet<Comment>();
            CourtDetails = new HashSet<CourtDetail>();
        }

        public int CourtId { get; set; }
        public int CategoryId { get; set; }
        public string CourtName { get; set; }
        public bool Status { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CourtDetail> CourtDetails { get; set; }
    }
}
