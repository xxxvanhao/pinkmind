using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rikkei.PindMind.DAO.Models
{
  public class Issue
  {
    public int ID { get; set; }
    public int IssueTypeID { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public int StatusID { get; set; }
    public int AssigneeUser { get; set; }
    public int PriorityID { get; set; }
    public int CategoryID { get; set; }
    public int MilestoneID { get; set; }
    public int VersionID { get; set; }
    public int? ResolutionID { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Due Date")]
    public DateTime DueDate { get; set; }
    public string ProjectID { get; set; }
    public long CreateBy { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Create At")]
    public DateTime CreateAt { get; set; }
    [Display(Name = "Update By")]
    public long UpdateBy { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Last Update")]
    public DateTime LastUpdate { get; set; }
    [Column(TypeName = "bit")]
    public bool DelFlag { get; set; }
    [Column(TypeName = "timestamp")]
    [Timestamp]
    public byte[] CheckUpdate { get; set; }
    public Project Project { get; set; }
    public IssueType IssueType { get; set; }
    public Status Status { get; set; }
    public Priority Priority { get; set; }
    public Category Category { get; set; }
    public Version Version { get; set; }
    public Milestone Milestone { get; set; }
    public Resolution Resolution { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Notify> Notifies { get; set; }
    public ICollection<User> User { get; set; }

  }
}
