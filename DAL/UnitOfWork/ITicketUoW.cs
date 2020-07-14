using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    public interface ITicketUoW
    {
        void Save();
        void Dispose();

        ProjectRepository Projects { get; }
        UserRepository Users { get; }
        SeverityRepository Severities { get; }
        PriorityRepository Priorities { get; }
        TicketRepository Tickets { get; }
        CommentRepository Comments { get; }
        TimelineRepository Timeline { get; }
        StatusRepository Status { get; }
    }
}
