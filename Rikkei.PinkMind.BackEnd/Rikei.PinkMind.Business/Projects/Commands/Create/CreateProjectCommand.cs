using MediatR;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Projects.Commands.Create
{
  public class CreateProjectCommand : IRequest
  {
    public string ID { get; set; }
    public string Name { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    [Timestamp]
    public byte[] CheckUpdate { get; set; }

    public class Handler : IRequestHandler<CreateProjectCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
      {
        var entity = new Project
        {
          ID = request.ID,
          Name = request.Name,
          CreateBy = request.CreateBy,
          CreateAt = DateTime.UtcNow,
          UpdateBy = request.UpdateBy,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        };
        _pmContext.Projects.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);

        var eTeam = new Team
        {
          Name = request.ID,
          CreateBy = request.CreateBy,
          CreateAt = DateTime.UtcNow,
          UpdateBy = request.UpdateBy,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        };
        _pmContext.Teams.Add(eTeam);
        await _pmContext.SaveChangesAsync();

        var eTeamDetails = new TeamDetail
        {
          UserID = request.CreateBy,
          TeamID = eTeam.ID,
          RoleID = 1,
          JoinedOn = DateTime.UtcNow,
          DelFlag = true
        };
        _pmContext.TeamDetails.Add(eTeamDetails);
        await _pmContext.SaveChangesAsync();

        var eTeamJoin = new TeamJoin
        {
          TeamID = eTeam.ID,
          ProjectID = request.ID,
          JoinOn = DateTime.UtcNow,
          DelFlag = true
        };
        _pmContext.TeamJoins.Add(eTeamJoin);
        await _pmContext.SaveChangesAsync();

        return Unit.Value;
      }
    }
  }
}
