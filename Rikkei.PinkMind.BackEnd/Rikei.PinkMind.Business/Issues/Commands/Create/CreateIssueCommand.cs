using MediatR;
using Microsoft.AspNetCore.Http;
using Rikei.PinkMind.Business.Files.Commands.Create;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Issues.Commands.Create
{

  public class CreateIssueCommand : IRequest
  {
    public int IssueTypeID { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public int StatusID { get; set; }
    public int AssigneeUser { get; set; }
    public int PriorityID { get; set; }
    public int CategoryID { get; set; }
    public int MilestoneID { get; set; }
    public int VersionID { get; set; }
    public int? ResolutionID { get; set; }
    public DateTime DueDate { get; set; }
    public string ProjectID { get; set; }
    public long CreateBy { get; set; }
    public long UpdateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public bool DelFlag { get; set; }
    [Timestamp]
    public byte[] CheckUpdate { get; set; }
    public List<IFormFile> File { get; set; }

    public class Handler : IRequestHandler<CreateIssueCommand, Unit>
    {
      private readonly IMediator _mediator;
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
      {
        try
        {
          var entity = new Issue
          {
            IssueTypeID = request.IssueTypeID,
            Subject = request.Subject,
            Description = request.Description,
            StatusID = request.StatusID,
            AssigneeUser = request.AssigneeUser,
            PriorityID = request.PriorityID,
            CategoryID = request.CategoryID,
            MilestoneID = request.MilestoneID,
            VersionID = request.VersionID,
            ResolutionID = request.ResolutionID,
            DueDate = request.DueDate,
            ProjectID = request.ProjectID,
            CreateBy = request.CreateBy,
            CreateAt = DateTime.UtcNow,
            UpdateBy = request.UpdateBy,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          };
          _pmContext.Issues.Add(entity);
          await _pmContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
          Debug.WriteLine(ex.Message);
        }
        ////Save files
        //if (request.File != null)
        //{
        //  int resID = entity.ID;
        //  var createFile = new CreateFileCommand();
        //  foreach (var item in request.File)
        //  {
        //    createFile.CommentID = null;
        //    createFile.CreateBy = request.CreateBy;
        //    createFile.UpdateBy = request.CreateBy;
        //    createFile.IssueID = resID;
        //  }
        //  var SaveFileContent = await _mediator.Send(new CreateFileCommand());
        //}
        return Unit.Value;
      }
    }
  }
}