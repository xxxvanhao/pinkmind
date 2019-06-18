using FluentValidation;
using Rikei.PinkMind.Business.Projects.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Projects.Commands.Create
{
  public class CreateProjectCommandValidator : AbstractValidator<ProjectModel>
  {
    public CreateProjectCommandValidator()
    {
      RuleFor(x => x.ID).NotEmpty();
      RuleFor(x => x.Name).NotNull();
      RuleFor(x => x.CreateAt).NotEmpty();
    }
  }
}
