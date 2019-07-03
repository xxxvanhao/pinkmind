using MediatR;
using Microsoft.AspNetCore.Http;
using Rikei.PinkMind.Business.Files.Commands.Create;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Issues.Commands.Create
{

  public class CreateIssueCommand : IRequest<int>
  {
    public int IssueTypeID { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public int StatusID { get; set; }
    public long? AssigneeUser { get; set; }
    public int? PriorityID { get; set; }
    public int? CategoryID { get; set; }
    public int? MilestoneID { get; set; }
    public int? VersionID { get; set; }
    public int? ResolutionID { get; set; }
    public DateTime DueDate { get; set; }
    public string ProjectID { get; set; }
    public long CreateBy { get; set; }
    public long UpdateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    [Timestamp]
    public byte[] CheckUpdate { get; set; }
    public List<CreateFileCommand> FileIssue { get; set; }
    public List<Int64> ListNotification { get; set; }

    public class Handler : IRequestHandler<CreateIssueCommand, int>
    {
      private readonly IMediator _mediator;
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<int> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
      {
        var status = _pmContext.Statuses.Where(it => it.Name == "Open").SingleOrDefault();

          var eIssue = new Issue
          {
            IssueTypeID = request.IssueTypeID,
            Subject = request.Subject,
            Description = request.Description,
            StatusID = status.ID,
            AssigneeUser = request.AssigneeUser,
            PriorityID = request.PriorityID,
            CategoryID = request.CategoryID,
            MilestoneID = request.MilestoneID,
            VersionID = request.VersionID,
            ResolutionID = request.ResolutionID,
            DueDate = request.DueDate,
            ProjectID = request.ProjectID,
            CreateBy = request.CreateBy,
            CreateAt = DateTime.Now,
            UpdateBy = request.UpdateBy,
            LastUpdate = DateTime.Now,
            DelFlag = true
          };
          _pmContext.Issues.Add(eIssue);
          await _pmContext.SaveChangesAsync(cancellationToken);

        var uDetails = await _pmContext.Users.FindAsync(request.CreateBy);
        string actineName = "added a new <span class='action'>issue</span>";
        var eReUpdate = new ReUpdateSpace
        {
          AvatarPath = uDetails.PictureUrl,
          UserName = $"{uDetails.FirstName} {uDetails.LastName}",
          ActionName = WebUtility.HtmlEncode(actineName),
          IssueKey = $"{request.ProjectID}-{eIssue.ID}",
          Subject = request.Subject,
          Content = request.Description,
          ProjectKey = request.ProjectID,
          SpaceID = uDetails.SpaceID,
          UpdateTime = DateTime.Now
        };
        _pmContext.ReUpdates.Add(eReUpdate);


        await _pmContext.SaveChangesAsync(cancellationToken);

        if(request.FileIssue.Count > 0) {
          foreach(var item in request.FileIssue)
          {
            var eFile = new File
            {
              FolderPath = item.FolderPath,
              FilePath = item.FilePath,
              FileSize = item.FileSize,
              CreateBy = request.CreateBy,
              CreateAt  = DateTime.Now,
              UpdateBy = request.UpdateBy,
              LastUpdate = DateTime.Now,
              DelFlag = true,
              IssueID = eIssue.ID
            };
            _pmContext.Files.Add(eFile);
            await _pmContext.SaveChangesAsync(cancellationToken);
          }
        }

        if(request.ListNotification.Count > 0)
        {
          foreach(var item in request.ListNotification)
          {
            var eNotify = new Notify
            {
              UserID = item,
              IssueID = eIssue.ID,
              ReupdateID =  eReUpdate.ID,
              Status = false
            };
            _pmContext.Notifies.Add(eNotify);
            await _pmContext.SaveChangesAsync(cancellationToken);
          }
        }
        return eIssue.ID;
      }
    }
  }
}
