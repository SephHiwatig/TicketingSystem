using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    public interface ITicketUoW
    {
        void Save();
        void Dispose();
    }
}
