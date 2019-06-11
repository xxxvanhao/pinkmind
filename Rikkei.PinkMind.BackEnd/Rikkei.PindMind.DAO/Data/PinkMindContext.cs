using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rikkei.PindMind.DAO.Models;
using Version = Rikkei.PindMind.DAO.Models.Version;

namespace Rikkei.PinkMind.DAO.Data
{
  public class PinkMindContext : DbContext
  {

    public PinkMindContext(DbContextOptions<PinkMindContext> options)
        : base(options)
    {
    }

    public DbSet<User> User { get; set; }
    public DbSet<Category> categories { get; set; }
    public DbSet<Comment> comments { get; set; }
    public DbSet<File> files { get; set; }
    public DbSet<Issue> issues { get; set; }
    public DbSet<IssueType> issueTypes { get; set; }
    public DbSet<Milestone> milestones { get; set; }
    public DbSet<Notify> notifies { get; set; }
    public DbSet<Priority> priorities { get; set; }
    public DbSet<Project> projects { get; set; }
    public DbSet<Resolution> resolutions { get; set; }
    public DbSet<ReUpdate> reUpdates { get; set; }
    public DbSet<Role> roles { get; set; }
    public DbSet<Status> statuses { get; set; }
    public DbSet<Team> teams { get; set; }
    public DbSet<TeamDetail> teamDetails { get; set; }
    public DbSet<TeamJoin> teamJoins { get; set; }
    public DbSet<Version> versions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().ToTable("tbl_user");
      modelBuilder.Entity<Role>().ToTable("tbl_role");
      modelBuilder.Entity<Team>().ToTable("tbl_team");
      modelBuilder.Entity<TeamDetail>().ToTable("tbl_teamdetail");
      modelBuilder.Entity<TeamJoin>().ToTable("tbl_teamjoin");
      modelBuilder.Entity<Project>().ToTable("tbl_project");
      modelBuilder.Entity<Issue>().ToTable("tbl_issue");
      modelBuilder.Entity<IssueType>().ToTable("tbl_issuetype");
      modelBuilder.Entity<Status>().ToTable("tbl_status");
      modelBuilder.Entity<Priority>().ToTable("tbl_priority");
      modelBuilder.Entity<Category>().ToTable("tbl_category");
      modelBuilder.Entity<Version>().ToTable("tbl_version");
      modelBuilder.Entity<Milestone>().ToTable("tbl_milestone");
      modelBuilder.Entity<Resolution>().ToTable("tbl_resolution");
      modelBuilder.Entity<Notify>().ToTable("tbl_notify");
      modelBuilder.Entity<File>().ToTable("tbl_file");
      modelBuilder.Entity<Comment>().ToTable("tbl_comment");
      modelBuilder.Entity<ReUpdate>().ToTable("tbl_reupdate");
    }
  }
}
