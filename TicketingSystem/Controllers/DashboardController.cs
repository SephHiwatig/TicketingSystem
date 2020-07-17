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
                .Include(x => x.Project)
                .OrderByDescending(x => x.TicketId);

            var pagedMyAssigned = await PagedList<Tickets>.CreateAsync(myAssigned, 1, 10);
            var mappedMyAssigned = _mapper.Map<IEnumerable<TicketForDashboardDto>>(pagedMyAssigned);
            var myAssignedPagination = new PaginationHeader(1, 10, pagedMyAssigned.TotalCount, pagedMyAssigned.TotalPages);

            var recentTickets = _ticketUoW
                .Tickets
                .GetAll()
                .Include(x => x.Project)
                .OrderByDescending(x => x.TicketId);

            var pagedRecentTickets = await PagedList<Tickets>.CreateAsync(recentTickets, 1, 10);
            var mappedRecentTickets = _mapper.Map<IEnumerable<TicketForDashboardDto>>(pagedRecentTickets);
            var recentTicketsPagination = new PaginationHeader(1, 10, pagedRecentTickets.TotalCount, pagedRecentTickets.TotalPages);

            var resolved = _ticketUoW
                .Tickets
                .Get(x => x.StatusId == 3 || x.StatusId == 4)
                .Include(x => x.Project)
                .OrderByDescending(x => x.TicketId);

            var pagedResolved = await PagedList<Tickets>.CreateAsync(resolved, 1, 10);
            var mappedResolved = _mapper.Map<IEnumerable<TicketForDashboardDto>>(pagedResolved);
            var resolvedPagination = new PaginationHeader(1, 10, pagedResolved.TotalCount, pagedResolved.TotalPages);

            var timeline = _ticketUoW
                .Timeline
                .GetAll()
                .OrderByDescending(x => x.TimelineId)
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

        [HttpGet("myassigned")]
        public async Task<IActionResult> GetMyAssigned([FromQuery] UserParams userParams)
        {
            var myAssigned = _ticketUoW
                .Tickets
                .Get(x => x.AssignedTo == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) &&
                    x.StatusId != 3 && x.StatusId != 4)
                .Include(x => x.Project)
                .OrderByDescending(x => x.TicketId);

            var pagedMyAssigned = await PagedList<Tickets>.CreateAsync(myAssigned, userParams.PageNumber, userParams.PageSize);
            Response.AddPagination(pagedMyAssigned.CurrentPage, pagedMyAssigned.PageSize, pagedMyAssigned.TotalCount, pagedMyAssigned.TotalPages);
            var mappedMyAssigned = _mapper.Map<IEnumerable<TicketForDashboardDto>>(pagedMyAssigned);

            return Ok(mappedMyAssigned);
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecents([FromQuery] UserParams userParams)
        {
            var recentTickets = _ticketUoW
                 .Tickets
                 .GetAll()
                 .Include(x => x.Project)
                 .OrderByDescending(x => x.TicketId);

            var pagedRecentTickets = await PagedList<Tickets>.CreateAsync(recentTickets, userParams.PageNumber, userParams.PageSize);
            Response.AddPagination(pagedRecentTickets.CurrentPage, pagedRecentTickets.PageSize, pagedRecentTickets.TotalCount, pagedRecentTickets.TotalPages);
            var mappedRecentTickets = _mapper.Map<IEnumerable<TicketForDashboardDto>>(pagedRecentTickets);

            return Ok(mappedRecentTickets);
        }

        [HttpGet("resolved")]
        public async Task<IActionResult> GetResolved([FromQuery] UserParams userParams)
        {
            var resolved = _ticketUoW
               .Tickets
               .Get(x => x.StatusId == 3 || x.StatusId == 4)
               .Include(x => x.Project)
               .OrderByDescending(x => x.TicketId);

            var pagedResolved = await PagedList<Tickets>.CreateAsync(resolved, userParams.PageNumber, userParams.PageSize);
            Response.AddPagination(pagedResolved.CurrentPage, pagedResolved.PageSize, pagedResolved.TotalCount, pagedResolved.TotalPages);
            var mappedResolved = _mapper.Map<IEnumerable<TicketForDashboardDto>>(pagedResolved);

            return Ok(pagedResolved);
        }

        [HttpGet("timeline")]
        public async Task<IActionResult> GetTimeline([FromQuery]UserParams userParams)
        {
            var timeline = _ticketUoW
                .Timeline
                .GetAll()
                .OrderByDescending(x => x.TimelineId)
                .Include(x => x.DoneByNavigation);

            var pagedTimeline = await PagedList<Timeline>.CreateAsync(timeline, userParams.PageNumber, userParams.PageSize);
            Response.AddPagination(pagedTimeline.CurrentPage, pagedTimeline.PageSize, pagedTimeline.TotalCount, pagedTimeline.TotalPages);
            var mappedTimeline = _mapper.Map<IEnumerable<TimelineDto>>(pagedTimeline);

            return Ok(mappedTimeline);
        }
    }
}
