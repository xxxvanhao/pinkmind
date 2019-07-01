using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Resolutions.Queries.GetAllResolution
{
    public class ResolutionDTO
    {
    public int ID { get; set; }
    public string Name { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public byte[] CheckUpdate { get; set; }
  }
}