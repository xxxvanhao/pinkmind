using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rikkei.PindMind.DAO.Models
{
  public class SeedData
  {
    private readonly PinkMindContext _pmContext;
    public SeedData(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public void CreateData(IServiceProvider serviceProvider)
    {
      //Data for tbl_Category
      if (_pmContext.Issues.ToList() == null)
      {
        //Data for IssueType
        _pmContext.Add(new IssueType
        {
          Name = "Task",
          CreateBy = 2591977,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 2591977,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
        _pmContext.Add(new IssueType
        {
          Name = "Bug",
          CreateBy = 2591977,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 2591977,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
        _pmContext.Add(new IssueType
        {
          Name = "Request",
          CreateBy = 2591977,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 2591977,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
        _pmContext.Add(new IssueType
        {
          Name = "Other",
          CreateBy = 2591977,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 2591977,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
        _pmContext.SaveChanges();
      }
      //Data for Mileston
      if (_pmContext.Milestones.ToList() == null)
      {
        _pmContext.Add(new Milestone
        {
          Name = "Phase1",
          CreateBy = 2591977,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 2591977,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
        _pmContext.Add(new Milestone
        {
          Name = "Phase2",
          CreateBy = 2591977,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 2591977,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
        _pmContext.Add(new Milestone
        {
          Name = "Phase3",
          CreateBy = 2591977,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 2591977,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
        _pmContext.Add(new Milestone
        {
          Name = "Phase4",
          CreateBy = 2591977,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 2591977,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
        _pmContext.SaveChanges();
      }
      //Data for Version
      if (_pmContext.Versions.ToList() == null)
      {
        _pmContext.Add(new Version
        {
          Name = "Phase1",
          CreateBy = 2591977,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 2591977,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
        _pmContext.Add(new Version
        {
          Name = "Phase2",
          CreateBy = 2591977,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 2591977,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
        _pmContext.Add(new Version
        {
          Name = "Phase3",
          CreateBy = 2591977,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 2591977,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
        _pmContext.Add(new Version
        {
          Name = "Phase4",
          CreateBy = 2591977,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 2591977,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
        _pmContext.SaveChanges();
      }
      //Data for Status
      if (_pmContext.Statuses.ToList() == null)
      {
        _pmContext.Add(new Status
        {
          Name = "Open",
          CreateBy = 2591977,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 2591977,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
        _pmContext.Add(new Status
        {
          Name = "in progress",
          CreateBy = 2591977,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 2591977,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
        _pmContext.Add(new Status
        {
          Name = "Resolve",
          CreateBy = 2591977,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 2591977,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
        _pmContext.Add(new Status
        {
          Name = "Close",
          CreateBy = 2591977,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 2591977,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
        _pmContext.SaveChanges();
      }
      //Data for Priority
      if (_pmContext.Priorities.ToList() == null)
      {
        _pmContext.Add(new Priority
        {
          Name = "Hight",
          CreateBy = 2591977,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 2591977,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
        _pmContext.Add(new Priority
        {
          Name = "Lower",
          CreateBy = 2591977,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 2591977,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
        _pmContext.Add(new Priority
        {
          Name = "Nomal",
          CreateBy = 2591977,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 2591977,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
        _pmContext.SaveChanges();
      }
    }
  }
}
