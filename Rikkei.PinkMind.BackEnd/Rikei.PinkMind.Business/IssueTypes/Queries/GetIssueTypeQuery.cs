using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.IssueTypes.Queries
{
    class GetIssueTypeQuery : IRequest<IssueTypeModel>
  {
    public long ID { get; set; }
  }
}
