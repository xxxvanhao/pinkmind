using MediatR;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.TeamDetails.Commands.Create
{
  public class CreateTeamDetailCommand : IRequest
  {
    public int ID { get; set; }
    public int UserID { get; set; }
    public int TeamID { get; set; }
    public int RoleID { get; set; }
    public DateTime JoinedOn { get; set; }
    public int AddBy { get; set; }
    public bool DelFlag { get; set; }

    public class Handler : IRequestHandler<CreateTeamDetailCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(CreateTeamDetailCommand request, CancellationToken cancellationToken)
      {
        var entity = new TeamDetail
        {
          ID = request.ID,
          RoleID = request.RoleID,
          TeamID = request.TeamID,
          UserID = request.UserID,
          JoinedOn = request.JoinedOn,
          AddBy = request.AddBy,
          DelFlag = request.DelFlag
        };
        _pmContext.TeamDetails.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
    }
  }
}
