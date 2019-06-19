using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.TeamDetails.Queries.GetTeamDetail
{
  public class GetTeamDetailQuery: IRequest<TeamDetailModel>
  {
    public int ID { get; set; }
  }
}
