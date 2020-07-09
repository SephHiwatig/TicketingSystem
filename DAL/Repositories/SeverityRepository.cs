using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class SeverityRepository : GenericRepository<Severities>
    {
        public SeverityRepository(ticketContext context) : base(context) { }
    }
}
