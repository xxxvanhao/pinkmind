using FluentValidation;
using Rikei.PinkMind.Business.Statuses.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Statuses.Commands.Create
{
  public class CreateStatusCommandValidator : AbstractValidator<StatusModel>
  {
    public CreateStatusCommandValidator()
    {
      RuleFor(x => x.Name).NotEmpty();
      RuleFor(x => x.CreateBy).NotEmpty();
    }
  }
}
