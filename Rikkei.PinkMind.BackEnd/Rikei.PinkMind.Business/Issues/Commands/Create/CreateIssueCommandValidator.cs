using FluentValidation;
using Rikei.PinkMind.Business.Issues.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Issues.Commands.Create
{
  public class CreateIssueCommandValidator : AbstractValidator<IssueModel>
  {
    public CreateIssueCommandValidator()
    {
      RuleFor(x => x.IssueKey).NotEmpty();
      RuleFor(x => x.Subject).NotEmpty();
      RuleFor(x => x.Description).NotEmpty();
      RuleFor(x => x.StatusID).NotEmpty();
      RuleFor(x => x.AssigneeUser).NotEmpty();
      RuleFor(x => x.PriorityID).NotEmpty();
      RuleFor(x => x.CategoryID).NotEmpty();
      RuleFor(x => x.MilestoneID).NotEmpty();
      RuleFor(x => x.VersionID).NotEmpty();
      RuleFor(x => x.ResolutionID).NotEmpty();
      RuleFor(x => x.DueDate).NotEmpty();
      RuleFor(x => x.ProjectID).NotEmpty();
      RuleFor(x => x.CreateBy).NotEmpty();
      RuleFor(x => x.UpdateBy).NotEmpty();
    }
  }
}
