using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.IssueTypes.Commands.Update
{
  public class UpdateIssueTypeCommandValidator : AbstractValidator<UpdateIssueTypeCommand>
  {
    public UpdateIssueTypeCommandValidator()
    {
      RuleFor(x => x.ID).NotEmpty();
      RuleFor(x => x.Name).NotEmpty();
      RuleFor(x => x.CheckUpdate).NotEmpty();
    }
  }
}
