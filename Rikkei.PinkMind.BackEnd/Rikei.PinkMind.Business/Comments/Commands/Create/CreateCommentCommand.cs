using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting.Internal;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Rikei.PinkMind.Business.Comments.Commands.Create
{
  public class CreateCommentCommand : IRequest
  {
    public int ID { get; set; }
    public string Content { get; set; }
    public int CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public bool DelFlag { get; set; }
    public long UpdateBy { get; set; }
    public IFormFile FileName { get; set; }
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
          UpdateBy = request.UpdateBy,
          LastUpdate = DateTime.UtcNow,
          FileName = "",
          DelFlag = true,          
        };
        _pmContext.Comments.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);
        if(request.FileName != null)
        {
          int returnID = entity.ID;
          entity.FileName = savefileAsync(request.IssueID, returnID, request.FileName);
          await _pmContext.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
      }
      public  string savefileAsync(int IssueID, int CommentID, IFormFile filename)
      {
        var path = Path.Combine(
                      Directory.GetCurrentDirectory(), "~/Issue/" + "Comment" + "/" + CommentID + "/");
        string TextFileName = filename.FileName;
        if (filename == null || filename.Length == 0)
        {
          using (var stream = new FileStream(path, FileMode.Create))
          {
             filename.CopyToAsync(stream);
          }
          return TextFileName;
        }
        return "0";
      }
    }
  }
}
