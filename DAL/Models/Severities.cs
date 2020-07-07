using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Severities
    {
        public Severities()
        {
            Tickets = new HashSet<Tickets>();
        }

        public int SeverityId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
