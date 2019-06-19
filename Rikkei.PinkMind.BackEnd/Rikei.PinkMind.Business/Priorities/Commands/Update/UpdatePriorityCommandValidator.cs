using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Priorities.Commands.Update
{
  class UpdatePriorityCommandValidator : AbstractValidator<UpdatePriorityCommand>
  {
    public UpdatePriorityCommandValidator()
    {
      RuleFor(u => u.ID).NotEmpty();
      RuleFor(u => u.Name).NotEmpty();
      RuleFor(u => u.CheckUpdate).NotEmpty();
    }
  }
}
