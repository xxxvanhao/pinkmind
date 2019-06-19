using MediatR;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Roles.Commands.Create
{
  public class CreateRoleCommand : IRequest
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public class Handler : IRequestHandler<CreateRoleCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
      {
        var entity = new Role
        {
          ID = request.ID,
          Name = request.Name
        };
        _pmContext.Roles.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
    }
  }
}
