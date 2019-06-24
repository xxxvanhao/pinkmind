using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Comments.Commands.Create
{
  public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
  {
    public CreateCommentCommandValidator()
    {
      RuleFor(u => u.Content).NotEmpty();
      RuleFor(u => u.IssueID).NotEmpty();
      RuleFor(u => u.CreateBy).NotEmpty();
    }
  }
}
