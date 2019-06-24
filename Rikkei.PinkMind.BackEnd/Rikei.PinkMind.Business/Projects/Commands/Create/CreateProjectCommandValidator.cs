using FluentValidation;
using Rikei.PinkMind.Business.Projects.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Projects.Commands.Create
{
  public class CreateProjectCommandValidator : AbstractValidator<ProjectViewModel>
  {
    public CreateProjectCommandValidator()
    {
    }
  }
}
