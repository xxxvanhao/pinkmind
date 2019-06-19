using MediatR;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Notifies.Commands.Create
{
  public class CreateNotifyCommand : IRequest
  {
    public long ID { get; set; }
    public long UserID { get; set; }
    public bool Status { get; set; }
    public long IssueID { get; set; }
    public class Handler : IRequestHandler<CreateNotifyCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(CreateNotifyCommand request, CancellationToken cancellationToken)
      {
        var entity = new Notify
        {
         
        };
        _pmContext.Notifies.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
    }
  }
}
