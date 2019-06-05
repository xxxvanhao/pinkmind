using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PinkMindDataAccess.Models
{
    [Table("tbl_file")]
    class File
    {
        [Key]
        public int fileId { get; set; }
        public string fileName { get; set; }
        public int updateBy { get; set; }
        public DateTime updateDate { get; set; }
        public DateTime createBY { get; set; }
        public DateTime createdate { get; set; }
    }
}
