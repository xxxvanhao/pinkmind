using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PinkMindDataAccess.Models
{
    [Table("tbl_version_mileston")]
    class VersionMileston
    {
        [Key]
        public int verId { get; set; }
        public string Name { get; set; }
        public int updateBy { get; set; }
        public DateTime updateDate { get; set; }
        public DateTime createBY { get; set; }
        public DateTime createdate { get; set; }
    }
}
