using FluentValidation;

namespace Rikei.PinkMind.Business.Versions.Commands.Update
{
  public class UpdateVersionCommandvalidator : AbstractValidator<UpdateVersionCommand>
  {
    public UpdateVersionCommandvalidator()
    {
      RuleFor(x => x.ID).NotEmpty();
      RuleFor(x => x.Name).NotEmpty();
    }
  }
}
