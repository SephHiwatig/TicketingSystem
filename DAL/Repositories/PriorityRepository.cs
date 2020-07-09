using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class PriorityRepository : GenericRepository<Priorities>
    {
        public PriorityRepository(ticketContext context) : base(context) { } 
    }
}
