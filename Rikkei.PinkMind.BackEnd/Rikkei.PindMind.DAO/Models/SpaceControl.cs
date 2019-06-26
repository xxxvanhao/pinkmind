using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rikkei.PindMind.DAO.Models
{
  public class SpaceControl
  {
    public int ID { get; set; }
    [Required]
    public string SpaceID { get; set; }
    [Required]
    public long ControlBy { get; set; }
    public Space Space { get; set; }
  }
}
