using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PinkMindDataAccess.Models
{
    [Table("tbl_teamDetail")]
    class TeamDetail
    {
        [Key]
        public int userId { get; set; }
        public int teamId { get; set; }
        public int roleID { get; set; }
        public int joinedOn { get; set; }
        public int addBy { get; set; }
        public int delFlag { get; set; }

    }
}
