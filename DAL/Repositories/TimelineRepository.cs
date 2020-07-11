using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class TimelineRepository : GenericRepository<Timeline>
    {
        public TimelineRepository(ticketContext context) : base(context) { }

    }
}
