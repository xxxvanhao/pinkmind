using FluentValidation;

namespace Rikei.PinkMind.Business.IssueTypes.Commands.Create
{
  public class CreateIssueTypeCommandValidator : AbstractValidator<CreateIssueTypeCommand>
  {
    public CreateIssueTypeCommandValidator()
    {
      RuleFor(u => u.Name).NotEmpty();
      RuleFor(u => u.CreateBy).NotEmpty();
    }
  }
}
