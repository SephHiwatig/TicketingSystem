using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
            TicketsAssignedToNavigation = new HashSet<Tickets>();
            TicketsCreatedByNavigation = new HashSet<Tickets>();
            Userroles = new HashSet<Userroles>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Tickets> TicketsAssignedToNavigation { get; set; }
        public virtual ICollection<Tickets> TicketsCreatedByNavigation { get; set; }
        public virtual ICollection<Userroles> Userroles { get; set; }
    }
}
