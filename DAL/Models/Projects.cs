using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DAL.Models
{
    public partial class Projects
    {
        public Projects()
        {
            Tickets = new HashSet<Tickets>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
