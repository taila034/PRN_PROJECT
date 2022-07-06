using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Models
{
    public partial class Category
    {
        public Category()
        {
            Courts = new HashSet<Court>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Court> Courts { get; set; }
    }
}
