using Rikei.PinkMind.Business.Comments.Queries.GetAllComment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Comments.Comments.GetAllComment
{
  public class CommentsViewModel
  {
    public IEnumerable<CommentsDTO> Comments { get; set; }
  }
}
