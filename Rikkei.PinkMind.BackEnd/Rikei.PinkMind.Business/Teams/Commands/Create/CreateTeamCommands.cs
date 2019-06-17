using MediatR;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Teams.Commands.Create
{
  class CreateTeamCommands : IRequest
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public int CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public int UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public string CheckUpdate { get; set; }
    public class Handler : IRequestHandler<CreateTeamCommands, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(CreateTeamCommands request, CancellationToken cancellationToken)
      {
        var entity = new Team
        {
          ID = request.ID,
          Name = request.Name,
          CreateAt = request.CreateAt,
          CreateBy = request.CreateBy,
          CheckUpdate = request.CheckUpdate,
          LastUpdate = request.LastUpdate,
          DelFlag = request.DelFlag,
          UpdateBy = request.UpdateBy

        };
        _pmContext.Teams.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }

    }
  }
}
