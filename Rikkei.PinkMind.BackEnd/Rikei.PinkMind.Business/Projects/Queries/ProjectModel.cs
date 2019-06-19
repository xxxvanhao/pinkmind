using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;

namespace Rikei.PinkMind.Business.Projects.Queries
{
  public class ProjectModel
  {
    public string ID { get; set; }
    public string Name { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    [Timestamp]
    public byte[] CheckUpdate { get; set; }
    public static Expression<Func<Project, ProjectModel>> Projection
    {
      get
      {
        return project => new ProjectModel
        {
          ID = project.ID,
          Name = project.Name,
          CreateAt = project.CreateAt,
          CreateBy = project.CreateBy,
          CheckUpdate = project.CheckUpdate,
          DelFlag = project.DelFlag,
          UpdateBy = project.UpdateBy,
          LastUpdate = project.LastUpdate
        };
      }
    }
    public static ProjectModel Create(Project project)
    {
      return Projection.Compile().Invoke(project);
    }
  }
}
