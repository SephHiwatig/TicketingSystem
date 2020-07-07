using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Userroles = new HashSet<Userroles>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Userroles> Userroles { get; set; }
    }
}
