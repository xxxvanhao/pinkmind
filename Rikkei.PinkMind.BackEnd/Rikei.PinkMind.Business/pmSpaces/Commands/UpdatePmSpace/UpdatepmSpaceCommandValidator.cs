using FluentValidation;
using Rikei.PinkMind.Business.Users.Commands.UpdateUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.pmSpaces.Commands.UpdatePmSpace
{
  class UpdatepmSpaceControlCommandValidator : AbstractValidator<UpdatepmSpaceCommand>
  {
   public UpdatepmSpaceControlCommandValidator()
    {
      RuleFor(x => x.SpaceID).NotEmpty();
      RuleFor(x => x.OrganizationName).NotEmpty();
    }
  }

}

