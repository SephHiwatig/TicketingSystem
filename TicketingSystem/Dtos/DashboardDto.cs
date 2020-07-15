using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Helpers;

namespace TicketingSystem.Dtos
{
    public class DashboardDto
    {
        public IEnumerable<TicketForDashboardDto> MyAssigned { get; set; }
        public IEnumerable<TicketForDashboardDto> RecentTickets { get; set; }
        public IEnumerable<TicketForDashboardDto> Resolved { get; set; }
        public IEnumerable<TimelineDto> Timeline { get; set; }

        public PaginationHeader MyAssignedPagination { get; set; }
        public PaginationHeader RecentTicketsPagination { get; set; }
        public PaginationHeader ResolvedPagination { get; set; }
        public PaginationHeader TimelinePagination { get; set; }
    }
}
