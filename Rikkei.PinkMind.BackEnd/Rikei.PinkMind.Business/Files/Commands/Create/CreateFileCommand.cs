using MediatR;
using Microsoft.AspNetCore.Http;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Files.Commands.Create
{
  public class CreateFileCommand : IRequest
  {
    public string FilePath { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public int DelFlag { get; set; }
    public int IssueID { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public IFormFile FileUpload { get; set; }
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
        string path = SavefileAsync(request.IssueID,request.CommentID, request.FileUpload);
        var entity = new Rikkei.PindMind.DAO.Models.File
        {
          FilePath = path,
          CreateBy = request.CreateBy,
          DelFlag = true,
          UpdateBy = request.UpdateBy,
          IssueID = request.IssueID,
          CommentID = request.CommentID,
        };
        await _pmContext.SaveChangesAsync(cancellationToken);
        _pmContext.Files.Add(entity);
        return Unit.Value;
      }
      public string SavefileAsync(int IssueID, int? CommentID, IFormFile filename)
      {
        var path = "";
        if (CommentID == null)
        {
         path = Path.Combine(
                      Directory.GetCurrentDirectory(), "~/Issue/" + IssueID + "/");
        }
        else
        {
          path = Path.Combine(
                      Directory.GetCurrentDirectory(), "~/Issue/" + "Comment/" + CommentID + "/");
        }
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
