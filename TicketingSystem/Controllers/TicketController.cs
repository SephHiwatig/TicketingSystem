using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Models;
using DAL.Repositories;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("get/{ticketId}")]
        public async Task<IActionResult> GetTicketById(int ticketId)
        {
            var ticket = await _ticketUoW.Tickets.Get(ticket => ticket.TicketId == ticketId)
                .Include(ticket => ticket.Project)
                .Include(ticket => ticket.AssignedToNavigation)
                .Include(ticket => ticket.CreatedByNavigation)
                .Include(ticket => ticket.Priority)
                .Include(ticket => ticket.Severity)
                .Include(ticket => ticket.Comments)
                    .ThenInclude(comment => comment.User)
                .FirstOrDefaultAsync();

            if (ticket == null)
                return NotFound();

            var users = _ticketUoW.Users.GetAll().ToArray();
            var status = _ticketUoW.Status.GetAll().ToArray();

            var mappedTicket = _mapper.Map<TicketDto>(ticket);
            var mappedusers = _mapper.Map<IEnumerable<UserFormDataDto>>(users);

            return Ok(new
            {
                ticket = mappedTicket,
                users = mappedusers,
                status
            });
        }

        [HttpGet("report-form-data")]
        public IActionResult GetReportFormData()
        {
            try
            {
                var projects = _ticketUoW.Projects.GetAll().ToArray();
                var users = _ticketUoW.Users.GetAll().ToArray();
                var severities = _ticketUoW.Severities.GetAll().ToArray();
                var priorities = _ticketUoW.Priorities.GetAll().ToArray();

                var userFormData = _mapper.Map<IEnumerable<UserFormDataDto>>(users);

                return Ok(new
                {
                    projects,
                    users = userFormData,
                    severities,
                    priorities
                });
            }
            catch (Exception e)
            {
                return Conflict(e);
            }
        }

        [HttpPost("report-issue")]
        public IActionResult SubmitIssue(ReportIssueFormDto reportIssueForm)
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var newTicket = new Tickets()
            {
                ProjectId = reportIssueForm.Project,
                AssignedTo = reportIssueForm.AssignTo,
                CreatedBy = currentUserId,
                DateCreated = DateTime.Now,
                Title = reportIssueForm.Title,
                Summary = reportIssueForm.Summary,
                SeverityId = reportIssueForm.Severity,
                PriorityId = reportIssueForm.Priority,
                StatusId = 1
            };

            if (!string.IsNullOrEmpty(reportIssueForm.Comment))
            {
                var newComment = new Comments()
                {
                    Comment = reportIssueForm.Comment,
                    CommentDate = DateTime.Now,
                    UserId = currentUserId,
                    TicketId = newTicket.TicketId
                };
                newTicket.Comments.Add(newComment);
            }

            var newTimeline = new Timeline()
            {
                TicketId = newTicket.TicketId,
                DoneBy = currentUserId,
                Action = "create",
                ActionDate = DateTime.Now
            };
            newTicket.Timelines.Add(newTimeline);

            _ticketUoW.Tickets.Insert(newTicket);
            _ticketUoW.Save();

            return StatusCode(201);
        }
    }
}
