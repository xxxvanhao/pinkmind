using MediatR;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Files.Commands.Create
{
  public class CreateFileCommand : IRequest
  {
    public string FilePath { get; set; }
    public int CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public int IssueID { get; set; }
    public int? CommentID { get; set; }
    public class Handler : IRequestHandler<CreateFileCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(CreateFileCommand request, CancellationToken cancellationToken)
      {
        var entity = new File
        {
          FilePath = request.FilePath,
          CreateBy = request.CreateBy,
          CreateAt = request.CreateAt,
          DelFlag = request.DelFlag,
          IssueID = request.IssueID,
          CommentID = request.CommentID,
        };
        _pmContext.Files.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
    }
  }
}
