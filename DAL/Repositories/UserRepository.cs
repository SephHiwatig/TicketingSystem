using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class UserRepository : GenericRepository<Users>
    {
        public UserRepository(ticketContext context) : base(context) { }
    }
}
