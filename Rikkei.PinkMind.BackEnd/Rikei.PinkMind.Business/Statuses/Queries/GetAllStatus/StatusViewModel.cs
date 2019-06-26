using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Statuses.Queries.GetAllStatus
{
  public class StatusViewModel
  {
    public IEnumerable<StatusDTO> statuses { get; set; }
  }
}
