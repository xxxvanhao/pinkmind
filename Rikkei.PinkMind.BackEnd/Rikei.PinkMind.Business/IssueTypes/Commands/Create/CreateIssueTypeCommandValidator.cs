using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.IssueTypes.Commands.Create
{
  class CreateIssueTypeCommandValidator : AbstractValidator<CreateIssueTypeCommand>
  {
    public CreateIssueTypeCommandValidator()
    {      
      RuleFor(u => u.Name).NotEmpty();
      RuleFor(u => u.CreateBy).NotEmpty();
    }
  }
}
