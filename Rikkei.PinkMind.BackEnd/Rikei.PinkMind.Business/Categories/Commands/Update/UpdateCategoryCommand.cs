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

namespace Rikei.PinkMind.Business.Categories.Commands.Update
{
  public class UpdateCategoryCommand : IRequest
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public int UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }

    public class Handler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }

      public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
      {
        var entity = await _pmContext.Categories.SingleOrDefaultAsync(u => u.ID == request.ID);
        if (entity == null)
        {
          throw new NotFoundException(nameof(Category), request.ID);
        }
        entity.Name = request.Name;
        entity.UpdateBy = request.UpdateBy;
        entity.LastUpdate = DateTime.UtcNow;        
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
    }
  }
}
