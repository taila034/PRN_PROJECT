using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string Contention { get; set; }
        public int? Vote { get; set; }
        public int AccountId { get; set; }
        public int CourtId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Court Court { get; set; }
    }
}
