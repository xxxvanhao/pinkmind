using FluentValidation;
using Rikei.PinkMind.Business.Statuses.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Statuses.Commands.Update
{
  public class UpdateStatusCommandValidator : AbstractValidator<StatusModel>
  {
    public UpdateStatusCommandValidator()
    {
      RuleFor(x => x.Name).NotEmpty();
      RuleFor(x => x.UpdateBy).NotEmpty();
    }
  }
}
