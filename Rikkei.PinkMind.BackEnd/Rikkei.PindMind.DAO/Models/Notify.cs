using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rikkei.PindMind.DAO.Models
{
  public class Notify
  {
    public int ID { get; set; }
    [Required]
    public long UserID { get; set; }
    [Column(TypeName = "bit")]
    public bool Status { get; set; }
    [Required]
    public int IssueID { get; set; }
    public int ReupdateID { get; set; }
    public Issue Issue { get; set; }
  }
}
