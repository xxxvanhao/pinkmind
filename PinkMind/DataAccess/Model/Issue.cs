using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Model
{
    [Table("Issues")]
    class Issue
    {
        [Column("issueId")]
        [Key]
        [Required]
        [Display(Name = "Issue Id")]
        public int issueId { get; set; }
        [Column("issueName")]
        [Required]
        [Display(Name = "Issue name")]
        [MaxLength(50)]
        public string issueName { get; set; }
        [Column("key")]
        [Required]
        [Display(Name = "key")]
        [MaxLength(50)]
        public string key { get; set; }
        [Column("issueTypeId")]
        [Required]
        [Display(Name = "Issue type")]
        [MaxLength(10)]
        public string issueTypeId { get; set; }
        public IssueType IssueType { get; set; }
        [Column("issueName")]
        [Required]
        [Display(Name = "Issue name")]
        public int assignee { get; set; }
        [Column("createDate")]
        [Required]
        [Display(Name = "Create Date")]
        public DateTime createDate { get; set; }
        [Column("dueDate")]
        [Required]
        [Display(Name = "Due date")]
        public DateTime dueDate { get; set; }
        [Column("update")]
        [Required]
        [Display(Name = "Update")]
        public DateTime update { get; set; }
        //Timestamp for check last update
        [Timestamp]
        public byte[] version { get; set; }
        //Foreign with issue Type
        public ICollection<IssueType> issueTypes { get; set; }

    }
}
