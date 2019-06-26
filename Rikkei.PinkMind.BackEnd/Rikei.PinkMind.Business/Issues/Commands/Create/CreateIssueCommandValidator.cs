using FluentValidation;
using Rikei.PinkMind.Business.Issues.Queries;

namespace Rikei.PinkMind.Business.Issues.Commands.Create
{
  public class CreateIssueCommandValidator : AbstractValidator<IssueModel>
  {
    public CreateIssueCommandValidator()
    {
      RuleFor(x => x.IssueTypeID).NotEmpty();
      RuleFor(x => x.StatusID).NotEmpty();
      RuleFor(x => x.ProjectID).NotEmpty();
      RuleFor(x => x.CreateBy).NotEmpty();
    }
  }
}
