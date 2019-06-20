using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.TeamDetails.Commands.Create
{
  public class CreateTeamDetailCommandValidator : AbstractValidator<CreateTeamDetailCommand>
  {
    public CreateTeamDetailCommandValidator()
    {
      RuleFor(t => t.TeamID).NotEmpty();
      RuleFor(t => t.RoleID).NotEmpty();
      RuleFor(t => t.UserID).NotEmpty();
    }
  }
}
