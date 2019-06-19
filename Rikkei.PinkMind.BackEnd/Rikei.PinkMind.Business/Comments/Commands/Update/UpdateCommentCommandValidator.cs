
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Comments.Commands.Update
{
    class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
  {
    public UpdateCommentCommandValidator()
    {
      RuleFor(u => u.ID).NotEmpty();
      RuleFor(u => u.Content).NotEmpty();
      RuleFor(u => u.UpdateBy).NotEmpty();   
    }
  }
}
