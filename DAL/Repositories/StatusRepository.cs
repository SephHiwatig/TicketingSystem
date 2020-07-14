using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class StatusRepository : GenericRepository<Statuses>
    {
        public StatusRepository(ticketContext context) : base(context) { }
    }
}
