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

namespace Rikei.PinkMind.Business.Roles.Commands.Update
{
  public class UpdateRoleCommand : IRequest
  {
    public int ID { get; set; }
    public string Name { get; set; }

    public class Handler : IRequestHandler<UpdateRoleCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }

      public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
      {
        var entity = await _pmContext.Roles.SingleOrDefaultAsync(u => u.ID == request.ID);
        if (entity == null)
        {
          throw new NotFoundException(nameof(Role), request.ID);
        }
        entity.ID = request.ID;
        entity.Name = request.Name;
        await _pmContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
      }
    }
  }
}
