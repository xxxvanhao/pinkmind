using FluentValidation;
using Rikei.PinkMind.Business.SpaceControls.Queries.GetpmSpaceControl;

namespace Rikei.PinkMind.Business.SpacesControls.Commands.CreatepmSpaceControl
{
  public class CreatepmSpaceControlCommandValidator : AbstractValidator<SpaceControlModel>
  {
    public CreatepmSpaceControlCommandValidator()
    {
      RuleFor(x => x.ID).NotEmpty();
      RuleFor(x => x.SpaceID).NotEmpty();
      RuleFor(x => x.ControlBy).NotEmpty();
    }
    
  }
}
