using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.pmSpaces.Commands.DeletepmSpace
{
  public class DeletepmSpaceCommand : IRequest
  {
    public string SpaceID { get; set; }
  }
}
