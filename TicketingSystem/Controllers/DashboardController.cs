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
                .Get(x => x.AssignedTo == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));

            var pagedMyAssigned = PagedList<Tickets>.CreateAsync(myAssigned, 1, 10);

            var recentTickets = _ticketUoW
                .Tickets
                .GetAll()
                .OrderByDescending(x => x.DateCreated);

            var pagedRecentTickets = PagedList<Tickets>.CreateAsync(recentTickets, 1, 10);

            var resolved = _ticketUoW
                .Tickets
                .Get(x => x.StatusId == 3);

            var pagedResolved = PagedList<Tickets>.CreateAsync(resolved, 1, 10);

            var timeline = _ticketUoW
                .Timeline
                .GetAll();

            var pagedTimeline = PagedList<Timeline>.CreateAsync(timeline, 1, 10);


        }

    }
}
