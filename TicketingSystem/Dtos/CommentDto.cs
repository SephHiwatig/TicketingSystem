using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingSystem.Dtos
{
    public class CommentDto
    {
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public UserFormDataDto User { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }
    }
}
