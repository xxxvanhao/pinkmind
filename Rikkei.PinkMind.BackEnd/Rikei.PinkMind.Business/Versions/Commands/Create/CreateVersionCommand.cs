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
  class CreateVersionCommand : IRequest
  {
    public long ID { get; set; }
    public string Name { get; set; }
    public int CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public int UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public string CheckUpdate { get; set; }
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
          LastUpdate = DateTime.UtcNow,
          UpdateBy = request.UpdateBy,
          CheckUpdate = request.CheckUpdate,
          DelFlag = request.DelFlag

        };
        _pmContext.Versions.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
    }
  }
}
