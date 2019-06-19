using FluentValidation;
using Rikei.PinkMind.Business.Projects.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Projects.Commands.Update
{
  public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
  {
    public UpdateProjectCommandValidator()
    {
      RuleFor(x => x.ID).NotEmpty();
      RuleFor(x => x.Name).NotEmpty();
      RuleFor(x => x.CreateAt).NotEmpty();
      RuleFor(x => x.CreateBy).NotEmpty();
    }
  }
}
