using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.IssueTypes.Queries.GetAllIssueType
{
  public class IssueTypesViewModel
  {
    public IEnumerable<IssueTypesDTO> IssueTypes { get; set; }
  }
}
