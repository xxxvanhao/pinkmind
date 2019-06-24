using MediatR;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Versions.Commands.Create
{
  public class CreateVersionCommand : IRequest
  {
    public string Name { get; set; }
    public int CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public bool DelFlag { get; set; }
    public class Handler : IRequestHandler<CreateVersionCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(CreateVersionCommand request, CancellationToken cancellationToken)
      {
        var entity = new Rikkei.PindMind.DAO.Models.Version
        {
          Name = request.Name,
          CreateAt = DateTime.UtcNow,
          CreateBy = request.CreateBy,
          DelFlag = request.DelFlag        
        };
        _pmContext.Versions.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
    }
  }
}
