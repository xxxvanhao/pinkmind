using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Issues.Search
{
    public class GetIssueSearchQuery : IRequest<IssueSearchViewModel>
    {
       public string Key { get; set; }
  }
}
