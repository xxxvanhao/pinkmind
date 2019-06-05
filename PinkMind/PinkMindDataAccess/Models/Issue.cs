using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PinkMindDataAccess.Models
{
    [Table("tbl_issue")]
    class Issue
    {
        [Key]
        [Display(Name = " Issue id")]
        public int issueId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string issueName { get; set; }
        public int issueTypeId { get; set; }
        public string issuekey { get; set; }
        public string subject { get; set; }
        public string description { get; set; }
        public int status { get; set; }
        public int assignee { get; set; }
        public int priority { get; set; }
        public int category { get; set; }
        public int milestion { get; set; }
        public int version { get; set; }
        public int resolution { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime createDate { get; set; }
        public int createBy { get; set; }
        public DateTime updateDate { get; set; }
        public int updateBy { get; set; }
        public DateTime lastUpdate { get; set; }
        public byte delFlag { get; set; }
        public int projectId { get; set; }
        public int notifyId { get; set; }
        public TimeSpan check { get; set; }

        public virtual IssueType IssueType { get; set; }
        //public virtual Priority Priority { get; set; }
        //public virtual Project Project { get; set; }
        //public virtual Version Version { get; set; }
    }
}