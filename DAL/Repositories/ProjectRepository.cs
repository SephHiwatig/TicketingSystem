using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class ProjectRepository : GenericRepository<Projects>
    {
        public ProjectRepository(ticketContext context) : base(context) { }
    }
}
