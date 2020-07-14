using AutoMapper;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Dtos;

namespace TicketingSystem.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, UserFormDataDto>();
            CreateMap<Comments, CommentDto>();
            CreateMap<Tickets, TicketDto>()
                .ForMember(dest => dest.ProjectName,
                    opt => opt.MapFrom(src => src.Project.ProjectName))
                .ForMember(dest => dest.ReportedBy,
                    opt => opt.MapFrom(src => src.CreatedByNavigation.Username))
                .ForMember(dest => dest.Priority,
                    opt => opt.MapFrom(src => src.Priority.Description))
                .ForMember(dest => dest.Severity,
                    opt => opt.MapFrom(src => src.Severity.Description));
        }
    }
}
