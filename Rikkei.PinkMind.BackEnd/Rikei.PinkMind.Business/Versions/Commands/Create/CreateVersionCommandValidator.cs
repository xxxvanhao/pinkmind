using FluentValidation;
using Rikei.PinkMind.Business.Versions.Queries.GetVersion;

namespace Rikei.PinkMind.Business.Versions.Commands.Create
{
  public class CreateVersionCommandValidator : AbstractValidator<VersionModel>
  {
    public CreateVersionCommandValidator()
    {
      RuleFor(x => x.Name).NotEmpty();
      RuleFor(x => x.CreateBy).NotEmpty();
    }
  }
}
