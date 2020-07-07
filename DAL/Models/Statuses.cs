using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Statuses
    {
        public Statuses()
        {
            Tickets = new HashSet<Tickets>();
        }

        public int StatusId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
