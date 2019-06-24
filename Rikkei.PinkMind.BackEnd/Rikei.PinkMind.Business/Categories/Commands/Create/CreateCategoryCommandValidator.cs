using FluentValidation;
using Rikei.PinkMind.Business.Categories.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Categories.Commands.Create
{
  public class CreateCategoryCommandValidator : AbstractValidator<CategoryModel>
  {
    public CreateCategoryCommandValidator()
    {
      RuleFor(x => x.Name).NotEmpty();
      RuleFor(x => x.CreateBy).NotEmpty();
    }
  }
}
