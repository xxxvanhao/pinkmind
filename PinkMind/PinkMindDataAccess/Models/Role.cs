using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PinkMindDataAccess.Models
{
    [Table("tbl_role")]
    class Role
    {
        [Key]
        public int roleId { get; set; }
        public string name { get; set; }
    }
}
