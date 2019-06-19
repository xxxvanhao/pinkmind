using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Teams.Commands.Update
{
  public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
  {
    public UpdateTeamCommandValidator()
    {
      RuleFor(x => x.ID).NotEmpty();
      RuleFor(x => x.Name).NotEmpty();
      RuleFor(x => x.UpdateBy).NotEmpty();
    }
  }
}
