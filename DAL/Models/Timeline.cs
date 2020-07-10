using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Timeline
    {
        public int TimelineId { get; set; }
        public int TicketId { get; set; }
        public int DoneBy { get; set; }
        public string Action { get; set; }
        public DateTime ActionDate { get; set; }

        public virtual Tickets Ticket { get; set; }
        public virtual Users DoneByNavigation { get; set; }
    }
}
