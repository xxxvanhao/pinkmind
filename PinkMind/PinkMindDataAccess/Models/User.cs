using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PinkMindDataAccess.Models
{
    [Table("tbl_user")]
    class User
    {
        [Key]
        public int userId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string avatarPath { get; set; }
        public string spaceId { get; set; }
        public string orgName { get; set; }
        public DateTime createDate { get; set; }
        public DateTime lastUpdate { get; set; }


    }
}
