using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.TeamDetails.Commands.Delete
{
    class DeleteTeamDetailCommand : IRequest
    {
    public int ID { get; set; }
    }
}
