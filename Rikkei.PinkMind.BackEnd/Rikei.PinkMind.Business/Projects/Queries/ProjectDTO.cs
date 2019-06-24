using System;

namespace Rikei.PinkMind.Business.Projects.Queries
{
  public class ProjectDTO
  {
    public string ID { get; set; }
    public string Name { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public byte[] CheckUpdate { get; set; }

  }
}
