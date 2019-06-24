using MediatR;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Statuses.Commands.Create
{
    public class CreateStatusCommand : IRequest<int>
    {
    public string Name { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public bool DelFlag { get; set; }
    public class Handler : IRequestHandler<CreateStatusCommand, int>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<int> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
      {
        var entity = new Status
        {
          Name = request.Name,
          CreateAt = DateTime.UtcNow,
          CreateBy = request.CreateBy,
          UpdateBy = request.UpdateBy,
          DelFlag = true
        };
        _pmContext.Statuses.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);
        return entity.ID;
      }

    }
  }
}
