using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingSystem.Dtos
{
    public class TicketDto
    {
        public int TicketId { get; set; }
        public Statuses Status { get; set; }
        public UserFormDataDto AssignedToNavigation { get; set; }
        public DateTime DateCreated { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ProjectName { get; set; }
        public string ReportedBy { get; set; }
        public string Priority { get; set; }
        public string Severity { get; set; }
        public ICollection<CommentDto> Comments { get; set; }

    }
}
