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
using TicketingSystem.Dtos;

namespace TicketingSystem.Controllers
{
    [Authorize]
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

            _ticketUoW.Tickets.Insert(newTicket);
            _ticketUoW.Save();

            if (!string.IsNullOrEmpty(reportIssueForm.Comment))
            {
                var newComment = new Comments()
                {
                    Comment = reportIssueForm.Comment,
                    CommentDate = DateTime.Now,
                    UserId = currentUserId,
                    TicketId = newTicket.TicketId
                };

                _ticketUoW.Comments.Insert(newComment);
            }

            var newTimeline = new Timeline()
            {
                TicketId = newTicket.TicketId,
                DoneBy = currentUserId,
                Action = "create",
                ActionDate = DateTime.Now
            };

            _ticketUoW.Timeline.Insert(newTimeline);

            _ticketUoW.Save();

            return StatusCode(201);
        }
    }
}
