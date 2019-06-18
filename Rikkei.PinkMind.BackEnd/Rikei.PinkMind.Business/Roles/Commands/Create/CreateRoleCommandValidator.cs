using FluentValidation;
using Rikei.PinkMind.Business.Roles.Queries.GetRole;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Roles.Commands.Create
{
  public class CreateRoleCommandValidator : AbstractValidator<RoleModel>
  {
    public CreateRoleCommandValidator()
    {
      RuleFor(x => x.Name).NotNull();
    }
  }
}
