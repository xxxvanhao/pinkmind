using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Users.Commands.UpdateUser
{
  public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
  {
    public UpdateUserCommandValidator()
    {
      RuleFor(u => u.ID).NotEmpty();
      RuleFor(u => u.Email).NotEmpty();
      RuleFor(u => u.Password).MinimumLength(8).MaximumLength(30);
      RuleFor(u => u.LastName).MinimumLength(3).MaximumLength(100);
      RuleFor(u => u.FirstName).MinimumLength(3).MaximumLength(100);
    }
  }
}
