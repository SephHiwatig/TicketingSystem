using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicketingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ITicketUoW _ticketUoW;
        private IHttpContextAccessor _httpContext;
        private IMapper _mapper;

        public AuthController(ITicketUoW ticketUoW,
                                 IHttpContextAccessor httpContextAccessor,
                                 IMapper mapper)
        {
            _ticketUoW = ticketUoW;
            _httpContext = httpContextAccessor;
            _mapper = mapper;
        }


    }
}
