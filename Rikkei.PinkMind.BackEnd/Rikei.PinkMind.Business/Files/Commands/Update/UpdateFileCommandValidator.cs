using FluentValidation;

namespace Rikei.PinkMind.Business.Files.Commands.Update
{
  public class UpdateFileCommandValidator : AbstractValidator<UpdateFileCommand>
  {
    public UpdateFileCommandValidator()
    {
      RuleFor(x => x.ID).NotEmpty();
      RuleFor(x => x.UpdateBy).NotEmpty();
    }
  }
}
