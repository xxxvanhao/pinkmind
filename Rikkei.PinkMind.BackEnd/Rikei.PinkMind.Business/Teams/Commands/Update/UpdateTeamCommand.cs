using MediatR;
using Microsoft.EntityFrameworkCore;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Teams.Commands.Update
{
  class UpdateTeamCommand : IRequest
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public int CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public int UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public string CheckUpdate { get; set; }
    public class Handler : IRequestHandler<UpdateTeamCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }

      public async Task<Unit> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
      {
        var entity = await _pmContext.Teams.SingleOrDefaultAsync(u => u.ID == request.ID);
        if (entity == null)
        {
          throw new NotFoundException(nameof(Teams), request.ID);
        }
        entity.ID = request.ID;
        entity.Name = request.Name;
        entity.CreateAt = request.CreateAt;
        entity.CreateBy = request.CreateBy;
        entity.CheckUpdate = request.CheckUpdate;
        entity.LastUpdate = request.LastUpdate;
        entity.DelFlag = request.DelFlag;
        entity.UpdateBy = request.UpdateBy;
        return Unit.Value;
      }
    }
  }
}
