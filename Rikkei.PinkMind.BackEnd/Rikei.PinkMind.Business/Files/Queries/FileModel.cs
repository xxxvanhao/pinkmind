using MediatR;
using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Rikei.PinkMind.Business.Files.Queries
{
    public class FileModel : IRequest
    {
    public long ID { get; set; }
    public string FilePath { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public byte[] CheckUpdate { get; set; }
    public long IssueID { get; set; }
    public long? CommentID { get; set; }
    public static Expression<Func<File, FileModel>> Projection
    {
      get
      {
        return file => new FileModel
        {
          ID = file.ID,
          FilePath = file.FilePath,
          CreateBy = file.CreateBy,
          CreateAt = file.CreateAt,
          LastUpdate = file.LastUpdate,
          IssueID = file.IssueID,          
          DelFlag = file.DelFlag,
          UpdateBy = file.UpdateBy,
          CheckUpdate = file.CheckUpdate,
          CommentID = file.CommentID
        };
      }
    }
    public static FileModel Create(File file)
    {
      return Projection.Compile().Invoke(file);
    }
  }
}
