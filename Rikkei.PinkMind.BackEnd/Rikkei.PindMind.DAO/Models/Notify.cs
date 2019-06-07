using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rikkei.PindMind.DAO.Models
{
    public class Notify
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        [Column(TypeName = "bit")]
        public bool Status { get; set; }
        public int IssueID { get; set; }
        public Issue Issue { get; set; }
    }
}
