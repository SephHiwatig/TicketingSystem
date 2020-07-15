using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingSystem.Dtos
{
    public class TicketForDashboardDto
    {
        public int TicketId { get; set; }
        public ProjectDto Project { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public int PriorityId { get; set; }
    }
}
