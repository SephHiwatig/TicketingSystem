using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class TicketRepository: GenericRepository<Tickets>
    {
        public TicketRepository(ticketContext context) : base(context) { }

    }
}
