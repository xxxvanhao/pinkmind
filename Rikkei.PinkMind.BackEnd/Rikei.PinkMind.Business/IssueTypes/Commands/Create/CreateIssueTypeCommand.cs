using MediatR;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.IssueTypes.Commands.Create
{
  public class CreateIssueTypeCommand : IRequest
  {
    public string Name { get; set; }
    public string BackgroundColor { get; set; }
    public int CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public bool DelFlag { get; set; }
    public class Handler : IRequestHandler<CreateIssueTypeCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(CreateIssueTypeCommand request, CancellationToken cancellationToken)
      {
        var entity = new IssueType
        {
          Name = request.Name,
          BackgroundColor = request.BackgroundColor,
          CreateBy = request.CreateBy,
          CreateAt = DateTime.UtcNow,
          DelFlag = true,
        };
        _pmContext.IssueTypes.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
    }
  }
}
