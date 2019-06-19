using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.TeamDetails.Queries.GetAllTeamDetail
{
  public class GetAllTeamDetailsQuery : IRequest<TeamDetailsViewModel>
  {
    public int ID { get; set; }
  }
}
