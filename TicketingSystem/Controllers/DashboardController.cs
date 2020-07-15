using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Models;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Dtos;
using TicketingSystem.Helpers;

namespace TicketingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private ITicketUoW _ticketUoW;
        private IMapper _mapper;

        public DashboardController(ITicketUoW ticketUoW,
                                 IMapper mapper)
        {
            _ticketUoW = ticketUoW;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboardInfo()
        {
            var myAssigned = _ticketUoW
                .Tickets
                .Get(x => x.AssignedTo == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) &&
                    x.StatusId != 3 && x.StatusId != 4)
                .Include(x => x.Project);

            var pagedMyAssigned = await PagedList<Tickets>.CreateAsync(myAssigned, 1, 10);
            var mappedMyAssigned = _mapper.Map<IEnumerable<TicketForDashboardDto>>(pagedMyAssigned);
            var myAssignedPagination = new PaginationHeader(1, 10, pagedMyAssigned.TotalCount, pagedMyAssigned.TotalPages);

            var recentTickets = _ticketUoW
                .Tickets
                .GetAll()
                .Include(x => x.Project)
                .OrderByDescending(x => x.DateCreated);

            var pagedRecentTickets = await PagedList<Tickets>.CreateAsync(recentTickets, 1, 10);
            var mappedRecentTickets = _mapper.Map<IEnumerable<TicketForDashboardDto>>(pagedRecentTickets);
            var recentTicketsPagination = new PaginationHeader(1, 10, pagedRecentTickets.TotalCount, pagedRecentTickets.TotalPages);

            var resolved = _ticketUoW
                .Tickets
                .Get(x => x.StatusId == 3 || x.StatusId == 4)
                .Include(x => x.Project);

            var pagedResolved = await PagedList<Tickets>.CreateAsync(resolved, 1, 10);
            var mappedResolved = _mapper.Map<IEnumerable<TicketForDashboardDto>>(pagedResolved);
            var resolvedPagination = new PaginationHeader(1, 10, pagedResolved.TotalCount, pagedResolved.TotalPages);

            var timeline = _ticketUoW
                .Timeline
                .GetAll()
                .OrderByDescending(x => x.ActionDate)
                .Include(x => x.DoneByNavigation);

            var pagedTimeline = await PagedList<Timeline>.CreateAsync(timeline, 1, 10);
            var mappedTimeline = _mapper.Map<IEnumerable<TimelineDto>>(pagedTimeline);
            var timelinePagination = new PaginationHeader(1, 10, pagedTimeline.TotalCount, pagedTimeline.TotalPages);

            var dashboard = new DashboardDto()
            {
                MyAssigned = mappedMyAssigned,
                MyAssignedPagination = myAssignedPagination,
                RecentTickets = mappedRecentTickets,
                RecentTicketsPagination = recentTicketsPagination,
                Resolved = mappedResolved,
                ResolvedPagination = resolvedPagination,
                Timeline = mappedTimeline,
                TimelinePagination = timelinePagination
            };

            return Ok(dashboard);
        }

    }
}
