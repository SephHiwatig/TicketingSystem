using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Comments
    {
        public int CommentId { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public int UserId { get; set; }
        public int TicketId { get; set; }

        public virtual Tickets Ticket { get; set; }
        public virtual Users User { get; set; }
    }
}
