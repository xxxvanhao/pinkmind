using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Resolutions.Commands.Delete
{
  public class DeleteResolutionCommand : IRequest
  {
    public int ID { get; set; }
  }
}
