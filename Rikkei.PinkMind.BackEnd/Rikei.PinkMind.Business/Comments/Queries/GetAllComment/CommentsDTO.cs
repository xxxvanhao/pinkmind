using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Comments.Queries.GetAllComment
{
  public class CommentsDTO
  {
    public int ID { get; set; }
    public string Content { get; set; }
    public long CreateBy { get; set; }
    public string CreateName { get; set; }
    public string PictureURL { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public byte[] CheckUpdate { get; set; }
    public int IssueID { get; set; }
  }
}
