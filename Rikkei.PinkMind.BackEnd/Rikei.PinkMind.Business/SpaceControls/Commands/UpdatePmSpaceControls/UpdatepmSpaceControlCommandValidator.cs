using FluentValidation;
using Rikei.PinkMind.Business.SpaceControls.Commands.UpdatePmSpaceControls;

namespace Rikei.PinkMind.Business.pmSpaces.Commands.UpdatePmSpaceControl
{
  public class UpdatepmSpaceControlCommandValidator : AbstractValidator<UpdatepmSpaceControlCommand>
  {
   public UpdatepmSpaceControlCommandValidator()
    {
      RuleFor(x => x.ID).NotEmpty();
      RuleFor(x => x.SpaceID).NotEmpty();
      RuleFor(x => x.ControlBy).NotEmpty();
    }
  }

}

