using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingSystem.Dtos
{
    public class TimelineDto
    {
        public int TimelineId { get; set; }
        public int TicketId { get; set; }
        public int DoneBy { get; set; }
        public string Action { get; set; }
        public DateTime ActionDate { get; set; }
        public UserFormDataDto DoneByNavigation { get; set; }
    }
}
