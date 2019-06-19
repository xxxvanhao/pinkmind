using FluentValidation;
using Rikei.PinkMind.Business.Categories.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Categories.Commands.Update
{
  public class UpdateCategoryCommandValidator : AbstractValidator<CategoryModel>
  {
    public UpdateCategoryCommandValidator()
    {
      RuleFor(x => x.Name).NotEmpty();
      RuleFor(x => x.UpdateBy).NotEmpty();
    }
  }
}
