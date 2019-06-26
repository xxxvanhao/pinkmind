using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Rikei.PinkMind.Business.Files.Commands.Create;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public List<IFormFile> FileName { get; set; }
    public int IssueID { get; set; }
    public class Handler : IRequestHandler<CreateCommentCommand, Unit>
    {
      private readonly IMediator _mediator;
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
        //Save file
        if(request.FileName != null)
        {
          int ReID = entity.ID;
          var createFile = new CreateFileCommand();
          foreach (var item in request.FileName)
          {
            createFile.CommentID = ReID;
            createFile.CreateBy = request.CreateBy;
            createFile.UpdateBy = request.UpdateBy;
            createFile.IssueID = request.IssueID;
          }
          var SavefileContent = await _mediator.Send(new CreateFileCommand());
        }
        return Unit.Value;
      }
    }
  }
}
