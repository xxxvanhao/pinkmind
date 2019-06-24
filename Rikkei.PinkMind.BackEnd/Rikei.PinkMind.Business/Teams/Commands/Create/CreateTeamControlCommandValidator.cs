using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Teams.Commands.Create
{
  public class CreateTeamControlCommandValidator : AbstractValidator<CreateTeamCommands>
  {
    public CreateTeamControlCommandValidator()
    {
      RuleFor(t => t.ID).NotEmpty();
      RuleFor(t => t.CreateBy).NotEmpty();
      RuleFor(t => t.Name).NotEmpty();
    }
  }
}
