using MediatR;
using Rikkei.PinkMind.DAO.Data;
using Rikkei.PindMind.DAO.Models;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.ReUpdate.Create
{
  public class CreateReUpdateCommand : IRequest
  {
    public int ID { get; set; }
    public string AvatarPath { get; set; }
    public string UserName { get; set; }
    public string ActionName { get; set; }
    public string IssueKey { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public DateTime UpdateTime { get; set; }
    public string SpaceID { get; set; }
    public string ProjectKey { get; set; }

    public class Handler : IRequestHandler<CreateReUpdateCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(CreateReUpdateCommand request, CancellationToken cancellationToken)
      {
        var entity = new ReUpdateSpace
        {
          AvatarPath = request.AvatarPath,
          UserName = request.UserName,
          ActionName = request.ActionName,
          IssueKey = request.IssueKey,
          Subject = request.Subject,
          Content = request.Content,
          UpdateTime  = DateTime.UtcNow,
          SpaceID = request.SpaceID,
          ProjectKey = request.ProjectKey
        };
        _pmContext.ReUpdates.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
      }
    }
  }
}
