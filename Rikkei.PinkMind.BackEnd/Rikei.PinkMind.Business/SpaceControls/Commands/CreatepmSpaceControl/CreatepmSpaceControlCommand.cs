using MediatR;
using Rikei.PinkMind.Business.Users.Commands.CreateUser;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.SpaceControls.Commands.CreatepmSpaceControl
{
  public class CreatepmSpaceControlCommand :IRequest
  {
    public string SpaceID { get; set; }
    public long ControlBy { get; set; }

    public class Handler : IRequestHandler<CreatepmSpaceControlCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(CreatepmSpaceControlCommand request, CancellationToken cancellationToken)
      {
        var entity = new SpaceControl
        {
          SpaceID = request.SpaceID,
          ControlBy = request.ControlBy
        };
        _pmContext.SpaceControls.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
    }
  }
}
