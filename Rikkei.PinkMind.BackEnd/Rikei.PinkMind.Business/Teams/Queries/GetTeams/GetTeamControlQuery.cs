using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikei.PinkMind.Business.SpaceControls.Queries.GetpmSpaceControl;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Teams.Queries.GetTeams
{
  class GetTeamControlQuery : IRequest<GetTeamModel>
  {
    public int ID { get; set; }
  }
}
