using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Milestones.Queries.GetMileston
{
    public class GetMilestoneQuery : IRequest<VersionModel>
    {
      public int ID { get; set; }
    }
}
