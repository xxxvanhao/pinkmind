using MediatR;
using Microsoft.EntityFrameworkCore;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Issues.Commands.Update
{
  public class UpdateIssueCommand : IRequest
  {
    public int ID { get; set; }
    public int IssueTypeID { get; set; }
    public string IssueKey { get; set; }
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
    public int UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }

    public class Handler : IRequestHandler<UpdateIssueCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }

      public async Task<Unit> Handle(UpdateIssueCommand request, CancellationToken cancellationToken)
      {
        var entity = await _pmContext.Issues.SingleOrDefaultAsync(u => u.ID == request.ID);
        if (entity == null)
        {
          throw new NotFoundException(nameof(Issue), request.ID);
        }
        entity.IssueTypeID = request.IssueTypeID;
        entity.IssueKey = request.IssueKey;
        entity.Subject = request.Subject;
        entity.Description = request.Description;
        entity.StatusID = request.StatusID;
        entity.AssigneeUser = request.AssigneeUser;
        entity.PriorityID = request.PriorityID;
        entity.CategoryID = request.CategoryID;
        entity.MilestoneID = request.MilestoneID;
        entity.VersionID = request.VersionID;
        entity.ResolutionID = request.ResolutionID;
        entity.DueDate = request.DueDate;
        entity.UpdateBy = request.UpdateBy;
        entity.LastUpdate = DateTime.UtcNow;
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
    }
  }
}
