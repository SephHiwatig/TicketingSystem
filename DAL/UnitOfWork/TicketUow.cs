using DAL.Models;
using DAL.Repositories;
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

        public ProjectRepository Projects => new ProjectRepository(_context);

        public UserRepository Users => new UserRepository(_context);

        public SeverityRepository Severities => new SeverityRepository(_context);

        public PriorityRepository Priorities => new PriorityRepository(_context);

        public TicketRepository Tickets => new TicketRepository(_context);

        public CommentRepository Comments => new CommentRepository(_context);

        public TimelineRepository Timeline => new TimelineRepository(_context);

        public StatusRepository Status => new StatusRepository(_context);

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
