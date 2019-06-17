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
      RuleFor(u => u.ID).NotEmpty();
      RuleFor(u => u.RoleID).NotEmpty();
      RuleFor(u => u.UserID).NotEmpty();
      RuleFor(u => u.JoinedOn).NotEmpty();
      RuleFor(u => u.AddBy).NotEmpty();
    }
  }
}
