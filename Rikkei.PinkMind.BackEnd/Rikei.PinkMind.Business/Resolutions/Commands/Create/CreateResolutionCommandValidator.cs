using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Resolutions.Commands.Create
{
  public class CreateResolutionCommandValidator : AbstractValidator<CreateResolutionCommand>
  {
    public CreateResolutionCommandValidator()
    {
      RuleFor(x => x.Name).NotNull();
      RuleFor(x => x.CreateBy).NotNull();
    }
  }
}
