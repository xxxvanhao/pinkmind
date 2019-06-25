using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Milestones.Commands.Update
{
  public class UpdateMilestoneCommandvalidator : AbstractValidator<UpdateMilestonCommand>
  {
    public UpdateMilestoneCommandvalidator()
    {
      RuleFor(x => x.ID).NotEmpty();
      RuleFor(x => x.Name).NotEmpty();
      RuleFor(x => x.CreateAt).NotEmpty();
      RuleFor(x => x.CreateBy).NotEmpty();
      RuleFor(x => x.LastUpdate).NotEmpty();
    }
  }
}