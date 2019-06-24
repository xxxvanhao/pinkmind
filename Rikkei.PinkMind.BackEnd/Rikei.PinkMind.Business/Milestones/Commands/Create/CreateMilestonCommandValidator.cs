using FluentValidation;
using Rikei.PinkMind.Business.Milestones.Queries.GetMileston;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Milestones.Commands.Create
{
  public class CreateVersionCommandValidator : AbstractValidator<VersionModel>
  {
    public CreateVersionCommandValidator()
    {
      RuleFor(x => x.Name).NotEmpty();
      RuleFor(x => x.CreateBy).NotEmpty();
    }
  }
}
