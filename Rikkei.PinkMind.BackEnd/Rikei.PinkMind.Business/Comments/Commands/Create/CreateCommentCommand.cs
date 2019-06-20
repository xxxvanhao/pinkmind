using MediatR;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Comments.Commands.Create
{
  public class CreateCommentCommand : IRequest
  {
    public string Content { get; set; }
    public int CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public bool DelFlag { get; set; }
    public int IssueID { get; set; }
    public class Handler : IRequestHandler<CreateCommentCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
      {
        var entity = new Comment
        {
          Content = request.Content,
          IssueID = request.IssueID,
          CreateAt = DateTime.UtcNow,
          CreateBy = request.CreateBy,
          DelFlag = true

        };
        _pmContext.Comments.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
    }
  }
}
