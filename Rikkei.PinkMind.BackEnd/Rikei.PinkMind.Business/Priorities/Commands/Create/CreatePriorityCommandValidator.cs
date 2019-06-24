using FluentValidation;

namespace Rikei.PinkMind.Business.Priorities.Commands.Create
{
  public class CreatePriorityCommandValidator : AbstractValidator<CreatePriorityCommand>
  {
    public CreatePriorityCommandValidator()
    {
      RuleFor(x => x.Name).NotEmpty();
      RuleFor(x => x.CreateBy).NotEmpty();
    }
  }
}
