using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Resolutions.Commands.Update
{
  public class UpdateResolutionCommandValidator : AbstractValidator<UpdateResolutionCommand>
  {
    public UpdateResolutionCommandValidator()
    {
      RuleFor(x => x.ID).NotEmpty();
      RuleFor(x => x.Name).NotNull();
    }
  }
}
