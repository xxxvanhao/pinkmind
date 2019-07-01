using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Linq;
using Version = Rikkei.PindMind.DAO.Models.Version;

namespace Rikkei.PindMind.DAO.Models
{
  public static class SeedData
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var _pmContext = new PinkMindContext(
                 serviceProvider.GetRequiredService<
                     DbContextOptions<PinkMindContext>>()))
      {
        //Data for tbl_Category
        if (!_pmContext.Categories.Any())
        {
          //Data for IssueType
          _pmContext.AddRange(new Category
          {
            Name = "Coding",
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true,
          },
          new Category
          {
            Name = "Basic Design",
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
         new Category
         {
           Name = "Infrastructure",
           CreateBy = 999999999999,
           CreateAt = DateTime.UtcNow,
           UpdateBy = 999999999999,
           LastUpdate = DateTime.UtcNow,
           DelFlag = true
         },
        new Category
        {
          Name = "Detail Design",
          CreateBy = 999999999999,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 999999999999,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        },
        new Category
        {
          Name = "Unit Test",
          CreateBy = 999999999999,
          CreateAt = DateTime.UtcNow,
          UpdateBy = 999999999999,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        });
          _pmContext.SaveChanges();
        }
        //
        if (!_pmContext.IssueTypes.Any())
        {
          //Data for IssueType
          _pmContext.AddRange(new IssueType
          {
            Name = "Task",
            BackgroundColor = "#b0be3c",
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new IssueType
          {
            Name = "Bug",
            CreateBy = 999999999999,
            BackgroundColor = "#ea2c00",
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
         new IssueType
         {
           Name = "Request",
           CreateBy = 999999999999,
           BackgroundColor = "#eda62a",
           CreateAt = DateTime.UtcNow,
           UpdateBy = 999999999999,
           LastUpdate = DateTime.UtcNow,
           DelFlag = true
         },
        new IssueType
        {
          Name = "Other",
          CreateBy = 999999999999,
          BackgroundColor = "#3b9dbd",
          CreateAt = DateTime.UtcNow,
          UpdateBy = 999999999999,
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
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Milestone
          {
            Name = "Phase 2",
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Milestone
          {
            Name = "Phase 3",
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          });
          _pmContext.SaveChanges();
        }
        //Data for Version
        if (!_pmContext.Versions.Any())
        {
          _pmContext.AddRange(new Version
          {
            Name = "1.0",
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Version
          {
            Name = "2.0",
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Version
          {
            Name = "3.0",
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          });
          _pmContext.SaveChanges();
        }
        //Data for Status
        if (!_pmContext.Statuses.Any())
        {
          _pmContext.AddRange(new Status
          {
            Name = "Open",
            BackgroundColor = "#ed8077",
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Status
          {
            Name = "In Progress",
            BackgroundColor = "#4488c5",
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Status
          {
            Name = "Resolved",
            BackgroundColor = "#5eb5a6",
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Status
          {
            Name = "Closed",
            BackgroundColor = "#b0be3c",
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
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
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Priority
          {
            Name = "Normal",
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Priority
          {
            Name = "Low",
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
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
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Resolution
          {
            Name = "Won't Fix",
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Resolution
          {
            Name = "Invalid",
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true
          },
          new Resolution
          {
            Name = "Duplication",
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
            LastUpdate = DateTime.UtcNow,
            DelFlag = true,
          },
          new Resolution
          {
            Name = "Can't Reproduce",
            CreateBy = 999999999999,
            CreateAt = DateTime.UtcNow,
            UpdateBy = 999999999999,
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
          new Role
          {
            Name = "Member",
          },
          new Role
          {
            Name = "Guest",
          });
          _pmContext.SaveChanges();
        }
      }
    }
  }
}
