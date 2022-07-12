using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.ViewModel
{
    public class CartItem
    {
        public List<int> OrderDetailID { get; set; }
        public List<int> CourtId { get; set; }
        public List<int> CourtDetailId { get; set; }
        public List<string> CourtName { get; set; }
        public List<decimal> Price { get; set; }
        public List<string> Slot { get; set; }
    }
}
