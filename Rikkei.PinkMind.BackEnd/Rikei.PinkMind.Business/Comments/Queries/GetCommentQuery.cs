using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Comments.Queries
{
  public class GetCommentQuery : IRequest<CommentModel>
  {
    public int ID { get; set; }
  }
}
