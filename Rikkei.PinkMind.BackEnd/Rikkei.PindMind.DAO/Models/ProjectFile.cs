using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rikkei.PindMind.DAO.Models
{
  public class ProjectFileUpload
  {
    [Key]
    public int ID { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string FolderPath { get; set; }
    [StringLength(50, MinimumLength = 3)]
    public string FilePath { get; set; }
    public string TypeModel { get; set; }
    public string FileSize { get; set; }
    public string ImagePath { get; set; }
    [Required]
    public long CreateBy { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Create At")]
    public DateTime CreateAt { get; set; }
    [Display(Name = "Update By")]
    [Required]
    public long UpdateBy { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Last Update")]
    public DateTime LastUpdate { get; set; }
    [Column(TypeName = "bit")]
    public bool DelFlag { get; set; }
    [Column(TypeName = "timestamp")]
    [Timestamp]
    public byte[] CheckUpdate { get; set; }
    public string ProjectID { get; set; }
    public Project Project { get; set; }
  }
}
