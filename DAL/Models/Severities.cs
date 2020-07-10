using System.Text.Json.Serialization;
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

        [JsonIgnore]
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
