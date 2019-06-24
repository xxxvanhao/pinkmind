using MediatR;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Categories.Commands.Create
{
  public class CreateCategoryCommand : IRequest
  {
    public string Name { get; set; }
    public int CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public bool DelFlag { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public class Handler : IRequestHandler<CreateCategoryCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
      {
        var entity = new Category
        {
          Name = request.Name,
          CreateAt = DateTime.UtcNow,
          CreateBy = request.CreateBy,
          UpdateBy = request.UpdateBy,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        };
        _pmContext.Categories.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
    }
  }
}
