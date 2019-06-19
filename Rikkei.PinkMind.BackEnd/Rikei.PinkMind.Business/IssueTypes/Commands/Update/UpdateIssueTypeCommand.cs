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

namespace Rikei.PinkMind.Business.IssueTypes.Commands.Update
{
  public class UpdateIssueTypeCommand : IRequest
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public string BackgroundColor { get; set; }
    public int UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public string CheckUpdate { get; set; }
    public class Handler : IRequestHandler<UpdateIssueTypeCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(UpdateIssueTypeCommand request, CancellationToken cancellationToken)
      {
        var entity = await _pmContext.IssueTypes.SingleOrDefaultAsync(u => u.ID == request.ID);
        if (entity == null)
        {
          throw new NotFoundException(nameof(IssueType), request.ID);
        }
        entity.ID = request.ID;
        entity.Name = request.Name;
        entity.BackgroundColor = request.BackgroundColor;
        entity.UpdateBy = request.UpdateBy;
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
    }
  }
}
