using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int CourtDetailsId { get; set; }

        public virtual CourtDetail CourtDetails { get; set; }
        public virtual Order Order { get; set; }
    }
}
