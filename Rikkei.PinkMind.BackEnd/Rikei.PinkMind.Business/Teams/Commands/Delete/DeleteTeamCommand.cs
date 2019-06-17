using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Teams.Commands.Delete
{
    class DeleteTeamCommand : IRequest
    {
      public int ID { get; set; }
    }
}
