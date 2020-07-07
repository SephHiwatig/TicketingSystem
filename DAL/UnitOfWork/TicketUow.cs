using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    public class TicketUow : IDisposable, ITicketUoW
    {
        private ticketContext _context;

        public TicketUow(ticketContext context)
        {
            this._context = context;
        }

        public void Save()
        {
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}
