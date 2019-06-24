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
    public DbSet<SpaceControl> SpaceControls { get; set; }
    public DbSet<Space> Spaces { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<File> Files { get; set; }
    public DbSet<Issue> Issues { get; set; }
    public DbSet<IssueType> IssueTypes { get; set; }
    public DbSet<Milestone> Milestones { get; set; }
    public DbSet<Notify> Notifies { get; set; }
    public DbSet<Priority> Priorities { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Resolution> Resolutions { get; set; }
    public DbSet<ReUpdate> ReUpdates { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TeamDetail> TeamDetails { get; set; }
    public DbSet<TeamJoin> TeamJoins { get; set; }
    public DbSet<Version> Versions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Space>().ToTable("tbl_space");
      modelBuilder.Entity<SpaceControl>().ToTable("tbl_spaceControl");
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
