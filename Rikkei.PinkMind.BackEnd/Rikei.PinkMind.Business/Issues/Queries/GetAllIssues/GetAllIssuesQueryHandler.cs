using AutoMapper;
using MediatR;
using Rikkei.PinkMind.DAO.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using Rikei.PinkMind.Business.Exceptions;

namespace Rikei.PinkMind.Business.Issues.Queries.GetAllIssues
{
  public class GetAllIssuesQueryHandler : IRequestHandler<GetAllIssuesQuery, IssuesViewModel>
  {
    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public GetAllIssuesQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }
    public async Task<IssuesViewModel> Handle(GetAllIssuesQuery request, CancellationToken cancellationToken)
    {            
      var issue = from iss in _pmContext.Issues
                  select new
                  {
                    iss.ID,
                    iss.IssueTypeID,
                    iss.IssueType.Name,
                    iss.Subject,
                    iss.Description,
                    iss.StatusID,
                    StatusName = iss.Status.Name,
                    iss.AssigneeUser,
                    iss.PriorityID,
                    PriorityName = iss.Priority.Name,
                    iss.CategoryID,
                    CategoryName = iss.Category.Name,
                    iss.MilestoneID,
                    MilestonName = iss.Milestone.Name,
                    iss.VersionID,
                    VersionName = iss.Version.Name,
                    iss.ResolutionID,
                    ResolutionName = iss.Resolution.Name,
                    iss.DueDate,
                    iss.ProjectID,
                    iss.CreateBy,
                    iss.UpdateBy,
                    iss.LastUpdate,
                    iss.DelFlag,
                    iss.CheckUpdate
                  };
      var List = await issue.ToListAsync(cancellationToken);
      var model = new IssuesViewModel
      {
        Issues = _mapper.Map<IEnumerable<IssuesDTO>>(List)
      };
      throw new NotFoundException("hihi", List);
        //return model;
      }
    }
  }

