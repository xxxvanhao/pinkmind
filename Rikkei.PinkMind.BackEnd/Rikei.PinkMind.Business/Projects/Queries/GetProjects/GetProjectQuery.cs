using MediatR;
using Rikei.PinkMind.Business.Projects.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Projects.Queries.GetProjects
{
  public class GetProjectQuery : IRequest<ProjectViewModel>
  {
    public long userID { get; set; }
  }
}
