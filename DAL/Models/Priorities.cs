using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Priorities
    {
        public Priorities()
        {
            Tickets = new HashSet<Tickets>();
        }

        public int PriorityId { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
