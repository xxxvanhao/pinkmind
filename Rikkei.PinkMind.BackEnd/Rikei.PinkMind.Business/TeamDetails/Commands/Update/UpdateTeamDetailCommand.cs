using MediatR;
using Microsoft.EntityFrameworkCore;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.TeamDetails.Commands.Update
{
  public class UpdateTeamDetailCommand : IRequest
  {
    public int ID { get; set; }
    public int UserID { get; set; }
    public int TeamID { get; set; }
    public int RoleID { get; set; }
    public DateTime JoinedOn { get; set; }
    public int AddBy { get; set; }
    public bool DelFlag { get; set; }
    public class Handler : IRequestHandler<UpdateTeamDetailCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(UpdateTeamDetailCommand request, CancellationToken cancellationToken)
      {
        var entity = await _pmContext.TeamDetails.SingleOrDefaultAsync(u => u.ID == request.ID);
        if (entity == null)
        {
          throw new NotFoundException(nameof(TeamDetails), request.ID);
        }

        entity.ID = request.ID;
        entity.RoleID = request.RoleID;
        entity.UserID = request.UserID;
        entity.TeamID = request.TeamID;
        entity.JoinedOn = request.JoinedOn;
        entity.AddBy = request.AddBy;
        entity.DelFlag = request.DelFlag;
        await _pmContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
      }
    }
  }
}
