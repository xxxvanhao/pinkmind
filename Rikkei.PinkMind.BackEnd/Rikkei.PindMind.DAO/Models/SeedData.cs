using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Linq;

namespace Rikkei.PindMind.DAO.Models
{
  public class SeedData
  {
    public void CreateData(IServiceProvider serviceProvider)
    {
      using (var _pmContext = new PinkMindContext(
                 serviceProvider.GetRequiredService<
                     DbContextOptions<PinkMindContext>>()))
      {
        //Data for tbl_Category
        if (!_pmContext.Issues.Any())
        {
          //Data for IssueType
          _pmContext.AddRange(new IssueType
          {
            Name = "Task",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new IssueType
          {
            Name = "Bug",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
         new IssueType
         {
           Name = "Request",
           CreateBy = 2591977,
           CreateAt = DateTime.UtcNow,
           UpdateBy = 2591977,
           LastUpdate = DateTime.UtcNow,
           DelFlag = true
         },
        new IssueType
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
        if (!_pmContext.Milestones.Any())
        {
          _pmContext.AddRange(new Milestone
          {
            Name = "Phase 1",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Milestone
          {
            Name = "Phase 2",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Milestone
          {
            Name = "Phase 3",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          });
          _pmContext.SaveChanges();
        }
        //Data for Version
        if (_pmContext.Versions.Any())
        {
          _pmContext.AddRange(new Version
          {
            Name = "1.0",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          (new Version
          {
            Name = "2.0",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Version
          {
            Name = "3.0",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          }));
          _pmContext.SaveChanges();
        }
        //Data for Status
        if (!_pmContext.Statuses.Any())
        {
          _pmContext.AddRange(new Status
          {
            Name = "Open",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Status
          {
            Name = "In Progress",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Status
          {
            Name = "Resolved",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Status
          {
            Name = "Closed",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          });
          _pmContext.SaveChanges();
        }
        //Data for Priority
        if (!_pmContext.Priorities.Any())
        {
          _pmContext.AddRange(new Priority
          {
            Name = "High",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Priority
          {
            Name = "Normal",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Priority
          {
            Name = "Low",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          });
          _pmContext.SaveChanges();
        }
        if (!_pmContext.Resolutions.Any())
        {
          _pmContext.AddRange(new Resolution
          {
            Name = "Fixed",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Resolution
          {
            Name = "Won't Fix",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Resolution
          {
            Name = "Invalid",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Resolution
          {
            Name = "Duplication",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Resolution
          {
            Name = "Can't Reproduce",
            CreateBy = 2591977,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 2591977,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          });
          _pmContext.SaveChanges();
        }
        if (!_pmContext.Roles.Any())
        {
          _pmContext.AddRange(new Role
          {
            Name = "Admin"
          },
          new Resolution
          {
            Name = "Member",
          },
          new Resolution
          {
            Name = "GUEST",
          });
          _pmContext.SaveChanges();
        }
      }
    }
  }
}
