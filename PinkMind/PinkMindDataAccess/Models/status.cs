using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PinkMindDataAccess.Models
{
    [Table("tbl_status")]
    class status
    {
        [Key]
        public int statusId { get; set; }
        public string name { get; set; }
        public int createBy { get; set; }
        public DateTime createDate { get; set; }
        public int updateBy { get; set; }
        public DateTime updateDate { get; set; }
        public byte Delflag { get; set; }
        public TimeSpan check { get; set; }
    }
}

