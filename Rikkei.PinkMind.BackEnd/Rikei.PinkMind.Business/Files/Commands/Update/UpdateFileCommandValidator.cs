using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Files.Commands.Update
{
  public class UpdateFileCommandValidator : AbstractValidator<UpdateFileCommand>
  {
    public UpdateFileCommandValidator()
    {
      RuleFor(x => x.ID).NotEmpty();
    }
  }
}
