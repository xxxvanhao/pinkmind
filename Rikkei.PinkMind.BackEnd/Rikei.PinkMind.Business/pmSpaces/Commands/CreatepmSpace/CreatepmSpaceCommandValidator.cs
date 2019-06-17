using FluentValidation;
using Rikei.PinkMind.Business.pmSpaces.Queries.GetpmSpace;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.pmSpaces.Commands.CreatepmSpace
{
  public class CreatepmSpaceControlCommandValidator : AbstractValidator<SpaceModel>
  {
    public CreatepmSpaceControlCommandValidator()
    {
      RuleFor(x => x.SpaceID).NotEmpty();
      RuleFor(x => x.OrganizationName).NotEmpty();
    }
    
  }
}
