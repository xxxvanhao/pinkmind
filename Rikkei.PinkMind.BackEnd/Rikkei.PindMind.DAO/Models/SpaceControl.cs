using System;
using System.Collections.Generic;
using System.Text;

namespace Rikkei.PindMind.DAO.Models
{
  public class SpaceControl
  {
    public int ID { get; set; }
    public string SpaceID { get; set; }
    public int ControlBy { get; set; }
    public Space Space { get; set; }
  }
}
