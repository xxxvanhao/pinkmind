using AutoMapper;
using Rikei.PinkMind.Business.Projects.Queries;
using Rikei.PinkMind.Business.ReUpdate.GetDetails;
using Rikei.PinkMind.Business.TeamDetails.Queries.GetAllTeamDetail;
using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.AutoMapper
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<TeamDetail, TeamDetailsDTO>()
        .ForMember(dest => dest.TeamID, opt => opt.MapFrom(src => src.TeamID))
        .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID));
      CreateMap<Project, ProjectDTO>()
        .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
       CreateMap<ReUpdateSpace, ReUpdateDTO>()
        .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
        .ForMember(dest => dest.SpaceID, opt => opt.MapFrom(src => src.SpaceID));
    }
  }
}
