using AutoMapper;
using MediatR;
using Rikei.PinkMind.Business.Issues.Queries.GetAllIssues;
using Rikkei.PinkMind.DAO.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Rikei.PinkMind.Business.Issues.Queries.SearchIssues
{
  public class SearchIssueQueryHandler : IRequestHandler<SearchIssueQuery, IssuesViewModel>
  {
    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public SearchIssueQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }
    public async Task<IssuesViewModel> Handle(SearchIssueQuery request, CancellationToken cancellationToken)
    {
      var Issue = from iss in _pmContext.Issues select new
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
      var SearchIssue = await Issue.ToListAsync(cancellationToken);
      if (request.ProjectID != null)
      {
        Issue.Where(x => x.ProjectID == request.ProjectID);
      }
      if (request.Key != null)
      {
        Issue.Where(x => x.Subject.Contains(request.ProjectID));
      }
      if (request.MilestoneID != 0)
      {
        Issue.Where(x => x.MilestoneID == request.MilestoneID);
      }
      if (request.StatusID != 0)
      {
        Issue.Where(x => x.StatusID == request.StatusID);
      }
      if (request.AssigneeUser != 0)
      {
        Issue.Where(x => x.AssigneeUser == request.AssigneeUser);
      }
      if (request.CategoryID != 0)
      {
        Issue.Where(x => x.CategoryID == request.CategoryID);
      }
      var model = new IssuesViewModel
      {
        Issues = _mapper.Map<IEnumerable<IssuesDTO>>(SearchIssue)
      };
      return model;

    }
  }
}
