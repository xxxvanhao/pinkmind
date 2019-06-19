using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Files.Commands.Delete
{
  public class DeleteFileCommand : IRequest
  {
    public long ID { get; set; }
  }
}
