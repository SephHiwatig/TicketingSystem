using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingSystem.Dtos
{
    public class UpdateTicketDto
    {
        public int TicketId { get; set; }
        public int FieldId { get; set; }
    }
}
