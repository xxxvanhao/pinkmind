using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Rikei.PinkMind.Business.Comments.Queries
{
  public class CommentModel
  {
    public int ID { get; set; }
    public string Content { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public string CheckUpdate { get; set; }
    public long IssueID { get; set; }
    public static Expression<Func<Comment, CommentModel>> Projection
    {
      get
      {
        return comment => new CommentModel
        {
          ID = comment.ID,
          Content = comment.Content,
          IssueID = comment.IssueID,
          CreateAt = DateTime.UtcNow,
          CreateBy = comment.CreateBy,
          UpdateBy = comment.UpdateBy,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true

        };
        
      }
    }
    public static CommentModel Create(Comment comment)
    {
      return Projection.Compile().Invoke(comment);
    }
  }
}
