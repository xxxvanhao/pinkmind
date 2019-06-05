using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Model
{
    [Table("IssueTypes")]
    class IssueType
    {
        [Key]
        [Column("IssueType")]
        [Required]
        [Display(Name = "Iuuse Id")]
        public int issueTypeId { get; set; }
        [Column("Issue Type Name")]
        [Required]
        [MaxLength(250)]
        public int issueTypeID { get; set; }
    }
}
