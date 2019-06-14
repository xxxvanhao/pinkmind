using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Users.Commands.CreateUser
{
  public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
  {
    public CreateUserCommandValidator()
    {
      RuleFor(u => u.ID).NotEmpty();
      RuleFor(u => u.Email).NotEmpty();
      RuleFor(u => u.Password).MinimumLength(8).MaximumLength(30);
    }
  }
}
