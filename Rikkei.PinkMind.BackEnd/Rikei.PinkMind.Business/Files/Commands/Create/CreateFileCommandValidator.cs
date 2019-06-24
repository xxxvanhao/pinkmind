using FluentValidation;

namespace Rikei.PinkMind.Business.Files.Commands.Create
{
  public class CreateFileCommandValidator : AbstractValidator<CreateFileCommand>
  {
    public CreateFileCommandValidator()
    {
      RuleFor(x => x.FilePath).NotEmpty();
      RuleFor(x => x.CreateBy).NotEmpty();
    }
  }
}
