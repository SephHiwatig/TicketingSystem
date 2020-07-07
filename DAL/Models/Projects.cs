using System;
using System.Collections.Generic;

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

        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
