using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Repositories;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Dtos;

namespace TicketingSystem.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketUoW _ticketUoW;
        private IMapper _mapper;

        public TicketController(ITicketUoW ticketUoW,
                                 IMapper mapper)
        {
            _ticketUoW = ticketUoW;
            _mapper = mapper;
        }

        [HttpGet("report-form-data")]
        public IActionResult GetReportFormData()
        {
            var projects = _ticketUoW.Projects.GetAll();
            var users = _ticketUoW.Users.GetAll();
            var severities = _ticketUoW.Severities.GetAll();
            var priorities = _ticketUoW.Priorities.GetAll();

            var userFormData = _mapper.Map<IEnumerable<UserFormDataDto>>(users);

            return Ok(new
            {
                projects,
                users = userFormData,
                severities,
                priorities
            });
        }
    }
}
