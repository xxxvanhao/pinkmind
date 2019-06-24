using MediatR;
using Microsoft.EntityFrameworkCore;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Milestones.Commands.Update
{
  public class UpdateMilestonCommand : IRequest
  {
    public long ID { get; set; }
    public string Name { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public string CheckUpdate { get; set; }
    public class Handler : IRequestHandler<UpdateMilestonCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }

      public async Task<Unit> Handle(UpdateMilestonCommand request, CancellationToken cancellationToken)
      {
        var entity = await _pmContext.Milestones.SingleOrDefaultAsync(u => u.ID == request.ID);
        if (entity == null)
        {
          throw new NotFoundException(nameof(Milestone), request.ID);
        }
        entity.Name = request.Name;
        return Unit.Value;
      }
    }
  }
}
