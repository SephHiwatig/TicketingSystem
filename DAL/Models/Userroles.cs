using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Userroles
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
