using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PinkMindDataAccess.Models
{
    [Table("tbl_project")]
    class Project
    {
        [Key]
        public int projectId { get; set; }
        public string name { get; set; }
        public string projectKey { get; set; }
        public int createBy { get; set; }
        public DateTime createDate { get; set; }
        public int updateBy { get; set; }
        public DateTime updateDate { get; set; }
        public byte delFlag { get; set; }
        public TimeSpan check { get; set; }
    }
}
