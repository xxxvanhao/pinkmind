using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rikei.PinkMind.Business.ProjectFile.GetAllFolder
{
  public class FileDTO
  {
    public int ID { get; set; }
    public string FolderPath { get; set; }
    public string FilePath { get; set; }
    public string TypeModel { get; set; }
    public string FileSize { get; set; }
    public string ImagePath { get; set; }
    public long CreateBy { get; set; }
    public string CreateName { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public string UpdateName { get; set; }
    public DateTime LastUpdate { get; set; }
    [Column(TypeName = "bit")]
    public bool DelFlag { get; set; }
    [Column(TypeName = "timestamp")]
    [Timestamp]
    public byte[] CheckUpdate { get; set; }
    public string ProjectID { get; set; }
  }
}
