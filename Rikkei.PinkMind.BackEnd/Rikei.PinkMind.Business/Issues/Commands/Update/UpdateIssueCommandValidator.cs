using FluentValidation;
using Rikei.PinkMind.Business.Issues.Queries;

namespace Rikei.PinkMind.Business.Issues.Commands.Update
{
  public class UpdateIssueCommandValidator : AbstractValidator<IssueModel>
  {
    public UpdateIssueCommandValidator()
    {
      RuleFor(x => x.ID).NotEmpty();
      RuleFor(x => x.IssueTypeID).NotEmpty();
      RuleFor(x => x.Subject).NotEmpty();
      RuleFor(x => x.StatusID).NotEmpty();
      RuleFor(x => x.AssigneeUser).NotEmpty();
      RuleFor(x => x.PriorityID).NotEmpty();
      RuleFor(x => x.CategoryID).NotEmpty();
      RuleFor(x => x.MilestoneID).NotEmpty();
      RuleFor(x => x.VersionID).NotEmpty();
      RuleFor(x => x.ResolutionID).NotEmpty();
      RuleFor(x => x.DueDate).NotEmpty();
      RuleFor(x => x.UpdateBy).NotEmpty();
    }
  }
}
