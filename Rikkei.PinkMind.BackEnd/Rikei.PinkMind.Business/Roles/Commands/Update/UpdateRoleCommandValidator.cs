using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Roles.Commands.Update
{
  public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
  {
    public UpdateRoleCommandValidator()
    {
      RuleFor(x => x.ID).NotEmpty();
      RuleFor(x => x.Name).NotNull();
    }
  }
}
