using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.TimerFeatures
{
  public class ChartModel
  {
    public List<int> Data { get; set; }
    public string Label { get; set; }

    public ChartModel()
    {
      Data = new List<int>();
    }
  }

}
