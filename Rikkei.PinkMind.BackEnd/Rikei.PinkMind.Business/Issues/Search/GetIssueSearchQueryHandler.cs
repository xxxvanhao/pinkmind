using AutoMapper;
using MediatR;
using Rikkei.PinkMind.DAO.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading; 
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Issues.Search
{
  public class GetIssueSearchQueryHandler : IRequestHandler<GetIssueSearchQuery, IssueSearchViewModel>
  {
    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public GetIssueSearchQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }
    public async Task<IssueSearchViewModel> Handle(GetIssueSearchQuery request, CancellationToken cancellationToken)
    {
      var user = from us in _pmContext.Users
                 select new
                 {
                   us.ID,
                   us.FullName,
                   us.PictureUrl
                 };
      var ListUser = _pmContext.Users.ToList();

      var issue = from iss in _pmContext.Issues
                  select new
                  {
                    iss.ID,
                    iss.Subject,
                    key = iss.ProjectID + " / " + iss.ID,
                    iss.CreateBy,
                    iss.AssigneeUser
                  };
      var List = await issue.Where(x => x.Subject.Contains(request.Key)).ToListAsync(cancellationToken);
      var modelIssue = new List<IssueSearchDTO>();
      foreach (var item in List)
      {
        var tfItem = new IssueSearchDTO();
        tfItem.Id = item.ID;
        tfItem.Subject = item.Subject;
        tfItem.CreateName = ListUser.SingleOrDefault(x => x.ID == item.CreateBy).FullName;
        var GetAssignee = ListUser.SingleOrDefault(x => x.ID == item.AssigneeUser);
        if (GetAssignee != null)
        {
          tfItem.AssigneeName = GetAssignee.FullName;
        }
        modelIssue.Add(tfItem);
      }

      var model = new IssueSearchViewModel
      {
        issueSearches = _mapper.Map<IEnumerable<IssueSearchDTO>>(modelIssue)
      };

      return model;
    }
  }
}
