using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class CommentRepository : GenericRepository<Comments>
    {
        public CommentRepository(ticketContext context) : base(context) { }
    }
}
