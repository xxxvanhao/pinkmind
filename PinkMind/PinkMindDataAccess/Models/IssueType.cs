using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PinkMindDataAccess.Models
{
    [Table("tbl_issueType")]
    class IssueType
    {
        [Key]
        public int issueTypeId { get; set; }
        public string issueTypeName { get; set; }
        public string backgroundColor { get; set; }
        public int createBy { get; set; }
        public DateTime createDate { get; set; }
        public int updateBy { get; set; }
        public DateTime updateDate { get; set; }
        public DateTime lastupdate { get; set; }
        public byte delFlag { get; set; }
        public TimeSpan check { get; set; }
    }
}
