using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Projects.Queries
{
    public class GetProjectQuery : IRequest<ProjectModel>
    {
    public int ID { get; set; }
  }
}
