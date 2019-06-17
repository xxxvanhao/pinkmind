using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.TeamDetails.Commands.Update
{
  public class UpdateTeamDetailCommandValidator : AbstractValidator<UpdateTeamDetailCommand>
  {
    public UpdateTeamDetailCommandValidator()
    {
      RuleFor(x => x.ID).NotEmpty();
      RuleFor(x => x.RoleID).NotEmpty();
      RuleFor(x => x.UserID).NotEmpty();
      RuleFor(x => x.TeamID).NotEmpty();
      RuleFor(x => x.JoinedOn).NotEmpty();
    }
  }
}
