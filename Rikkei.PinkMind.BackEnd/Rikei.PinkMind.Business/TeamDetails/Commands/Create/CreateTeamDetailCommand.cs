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
  public class CreateTeamDetailCommand : IRequest<int>
  {
    public int ID { get; set; }
    public long UserID { get; set; }
    public int TeamID { get; set; }
    public int RoleID { get; set; }
    public DateTime JoinedOn { get; set; }
    public long AddBy { get; set; }
    public bool DelFlag { get; set; }

    public class Handler : IRequestHandler<CreateTeamDetailCommand, int>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<int> Handle(CreateTeamDetailCommand request, CancellationToken cancellationToken)
      {
        var entity = new TeamDetail
        {
          TeamID = request.TeamID,
          UserID = request.UserID,
          RoleID = request.RoleID,
          JoinedOn = DateTime.Now,
          AddBy = request.AddBy,
          DelFlag = true
        };
        _pmContext.TeamDetails.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);
        return entity.ID;
      }
    }
  }
}
