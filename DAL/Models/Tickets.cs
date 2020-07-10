using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Tickets
    {
        public Tickets()
        {
            Comments = new HashSet<Comments>();
            Timelines = new HashSet<Timeline>();
        }

        public int TicketId { get; set; }
        public int ProjectId { get; set; }
        public int StatusId { get; set; }
        public int AssignedTo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int SeverityId { get; set; }
        public int PriorityId { get; set; }

        public virtual Users AssignedToNavigation { get; set; }
        public virtual Users CreatedByNavigation { get; set; }
        public virtual Priorities Priority { get; set; }
        public virtual Projects Project { get; set; }
        public virtual Severities Severity { get; set; }
        public virtual Statuses Status { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Timeline> Timelines { get; set; }
    }
}
