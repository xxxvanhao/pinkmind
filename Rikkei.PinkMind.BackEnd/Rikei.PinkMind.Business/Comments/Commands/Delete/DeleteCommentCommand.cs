using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Comments.Commands.Delete
{
  public class DeleteCommentCommand : IRequest
  {
    public long ID { get; set; }
  }
}
