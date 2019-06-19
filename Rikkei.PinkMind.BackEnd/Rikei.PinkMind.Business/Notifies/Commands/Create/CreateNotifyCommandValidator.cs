using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Notifies.Commands.Create
{
  public class CreateNotifyCommandValidator : AbstractValidator<CreateNotifyCommand>
  {
    public CreateNotifyCommandValidator()
    {
      RuleFor(x => x.IssueID).NotEmpty();
      RuleFor(x => x.UserID).NotEmpty();
    }
  }
}
