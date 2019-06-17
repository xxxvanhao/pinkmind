using MediatR;
using Microsoft.EntityFrameworkCore;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.SpaceControls.Commands.UpdatePmSpaceControls
{
  public class UpdatepmSpaceControlCommand : IRequest
  {
    public int ID { get; set; }
    public string SpaceID { get; set; }
    public int ControlBy { get; set; }

    public class Handler : IRequestHandler<UpdatepmSpaceControlCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }

      public async Task<Unit> Handle(UpdatepmSpaceControlCommand request, CancellationToken cancellationToken)
      {
        var entity = await _pmContext.SpaceControls.SingleOrDefaultAsync(u => u.SpaceID == request.SpaceID);
        if (entity == null)
        {
          throw new NotFoundException(nameof(SpaceControl), request.SpaceID);
        }
        entity.ID = request.ID;
        entity.SpaceID = request.SpaceID;
        entity.ControlBy = request.ControlBy;        
        return Unit.Value;
      }
    }

  }
}
