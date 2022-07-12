using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BusinessObject.Models
{
    public partial class CourtDetail
    {
        public CourtDetail()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int CourtDetailsId { get; set; }
        public int CourtId { get; set; }
        [Required]
        public TimeSpan StartAt { get; set; }
        [Required]
        public TimeSpan EndAt { get; set; }
        public string Slot { get; set; }
        public bool Status { get; set; }

        public virtual Court Court { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
