﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rikkei.PinkMind.DAO.Data;

namespace Rikkei.PinkMind.Migrator.Migrations
{
    [DbContext(typeof(PinkMindContext))]
    partial class PinkMindContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("CheckUpdate")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("CreateAt");

                    b.Property<long>("CreateBy");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<long>("UpdateBy");

                    b.HasKey("ID");

                    b.ToTable("tbl_category");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("CheckUpdate")
                        .HasColumnType("timestamp");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateAt");

                    b.Property<long>("CreateBy");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("bit");

                    b.Property<int>("IssueID");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<long>("UpdateBy");

                    b.HasKey("ID");

                    b.HasIndex("IssueID");

                    b.ToTable("tbl_comment");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.File", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("CheckUpdate")
                        .HasColumnType("timestamp");

                    b.Property<int?>("CommentID");

                    b.Property<DateTime>("CreateAt");

                    b.Property<long>("CreateBy");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("bit");

                    b.Property<string>("FilePath")
                        .HasMaxLength(50);

                    b.Property<int>("IssueID");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<long>("UpdateBy");

                    b.HasKey("ID");

                    b.HasIndex("CommentID");

                    b.HasIndex("IssueID");

                    b.ToTable("tbl_file");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.Issue", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssigneeUser");

                    b.Property<int>("CategoryID");

                    b.Property<byte[]>("CheckUpdate")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("CreateAt");

                    b.Property<long>("CreateBy");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("bit");

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueDate");

                    b.Property<string>("IssueKey");

                    b.Property<int>("IssueTypeID");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<int>("MilestoneID");

                    b.Property<int>("PriorityID");

                    b.Property<string>("ProjectID");

                    b.Property<int?>("ResolutionID");

                    b.Property<int>("StatusID");

                    b.Property<string>("Subject");

                    b.Property<long>("UpdateBy");

                    b.Property<int>("VersionID");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("IssueTypeID");

                    b.HasIndex("MilestoneID");

                    b.HasIndex("PriorityID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("ResolutionID");

                    b.HasIndex("StatusID");

                    b.HasIndex("VersionID");

                    b.ToTable("tbl_issue");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.IssueType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BackgroundColor")
                        .IsRequired();

                    b.Property<byte[]>("CheckUpdate")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("CreateAt");

                    b.Property<long>("CreateBy");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<long>("UpdateBy");

                    b.HasKey("ID");

                    b.ToTable("tbl_issuetype");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.Milestone", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("CheckUpdate")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("CreateAt");

                    b.Property<long>("CreateBy");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<long>("UpdateBy");

                    b.HasKey("ID");

                    b.ToTable("tbl_milestone");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.Notify", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IssueID");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<long>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("IssueID");

                    b.ToTable("tbl_notify");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.Priority", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("CheckUpdate")
                        .HasColumnType("timestamp");

                    b.Property<long>("CreateAt");

                    b.Property<int>("CreateBy");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<long>("UpdateBy");

                    b.HasKey("ID");

                    b.ToTable("tbl_priority");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.Project", b =>
                {
                    b.Property<string>("ID");

                    b.Property<byte[]>("CheckUpdate")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("CreateAt");

                    b.Property<long>("CreateBy");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<long>("UpdateBy");

                    b.HasKey("ID");

                    b.ToTable("tbl_project");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.ReUpdate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionName");

                    b.Property<string>("AvatarPath");

                    b.Property<string>("Content");

                    b.Property<string>("IssueKey");

                    b.Property<string>("Subject");

                    b.Property<string>("UpdateTime");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.ToTable("tbl_reupdate");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.Resolution", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("CheckUpdate")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("CreateAt");

                    b.Property<long>("CreateBy");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<long>("UpdateBy");

                    b.HasKey("ID");

                    b.ToTable("tbl_resolution");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("tbl_role");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.Space", b =>
                {
                    b.Property<string>("SpaceID")
                        .HasMaxLength(50);

                    b.Property<byte[]>("CheckUpdate")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("CreateAt");

                    b.Property<long>("CreateBy");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("OrganizationName")
                        .HasMaxLength(50);

                    b.Property<long>("UpdateBy");

                    b.HasKey("SpaceID");

                    b.ToTable("tbl_space");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.SpaceControl", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ControlBy");

                    b.Property<string>("SpaceID");

                    b.HasKey("ID");

                    b.HasIndex("SpaceID");

                    b.ToTable("tbl_spaceControl");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.Status", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("CheckUpdate")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("CreateAt");

                    b.Property<long>("CreateBy");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<long>("UpdateBy");

                    b.HasKey("ID");

                    b.ToTable("tbl_status");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.Team", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("CheckUpdate")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("CreateAt");

                    b.Property<long>("CreateBy");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<long>("UpdateBy");

                    b.HasKey("ID");

                    b.ToTable("tbl_team");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.TeamDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AddBy");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("JoinedOn");

                    b.Property<int>("RoleID");

                    b.Property<int>("TeamID");

                    b.Property<long>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.HasIndex("TeamID");

                    b.HasIndex("UserID");

                    b.ToTable("tbl_teamdetail");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.TeamJoin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AddBy");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("JoinOn");

                    b.Property<string>("ProjectID");

                    b.Property<int>("TeamID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("TeamID");

                    b.ToTable("tbl_teamjoin");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.User", b =>
                {
                    b.Property<long>("ID");

                    b.Property<DateTime>("CreateAt");

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Password")
                        .HasMaxLength(50);

                    b.Property<string>("PictureUrl");

                    b.Property<string>("SpaceID")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("SpaceID");

                    b.ToTable("tbl_user");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.Version", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("CheckUpdate")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("CreateAt");

                    b.Property<int>("CreateBy");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("UpdateBy");

                    b.HasKey("ID");

                    b.ToTable("tbl_version");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.Comment", b =>
                {
                    b.HasOne("Rikkei.PindMind.DAO.Models.Issue", "Issue")
                        .WithMany("Comments")
                        .HasForeignKey("IssueID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.File", b =>
                {
                    b.HasOne("Rikkei.PindMind.DAO.Models.Comment", "Comment")
                        .WithMany()
                        .HasForeignKey("CommentID");

                    b.HasOne("Rikkei.PindMind.DAO.Models.Issue", "Issue")
                        .WithMany("Files")
                        .HasForeignKey("IssueID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.Issue", b =>
                {
                    b.HasOne("Rikkei.PindMind.DAO.Models.Category", "Category")
                        .WithMany("Issues")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rikkei.PindMind.DAO.Models.IssueType", "IssueType")
                        .WithMany("Issues")
                        .HasForeignKey("IssueTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rikkei.PindMind.DAO.Models.Milestone", "Milestone")
                        .WithMany("Issues")
                        .HasForeignKey("MilestoneID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rikkei.PindMind.DAO.Models.Priority", "Priority")
                        .WithMany("Issues")
                        .HasForeignKey("PriorityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rikkei.PindMind.DAO.Models.Project", "Project")
                        .WithMany("Issues")
                        .HasForeignKey("ProjectID");

                    b.HasOne("Rikkei.PindMind.DAO.Models.Resolution", "Resolution")
                        .WithMany("Issues")
                        .HasForeignKey("ResolutionID");

                    b.HasOne("Rikkei.PindMind.DAO.Models.Status", "Status")
                        .WithMany("Issues")
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rikkei.PindMind.DAO.Models.Version", "Version")
                        .WithMany("Issues")
                        .HasForeignKey("VersionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.Notify", b =>
                {
                    b.HasOne("Rikkei.PindMind.DAO.Models.Issue", "Issue")
                        .WithMany("Notifies")
                        .HasForeignKey("IssueID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.SpaceControl", b =>
                {
                    b.HasOne("Rikkei.PindMind.DAO.Models.Space", "Space")
                        .WithMany("SpaceControls")
                        .HasForeignKey("SpaceID");
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.TeamDetail", b =>
                {
                    b.HasOne("Rikkei.PindMind.DAO.Models.Role", "Role")
                        .WithMany("TeamDetails")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rikkei.PindMind.DAO.Models.Team", "Team")
                        .WithMany("TeamDetails")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rikkei.PindMind.DAO.Models.User", "User")
                        .WithMany("TeamDetails")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.TeamJoin", b =>
                {
                    b.HasOne("Rikkei.PindMind.DAO.Models.Project", "Project")
                        .WithMany("TeamJoins")
                        .HasForeignKey("ProjectID");

                    b.HasOne("Rikkei.PindMind.DAO.Models.Team", "Team")
                        .WithMany("TeamJoins")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rikkei.PindMind.DAO.Models.User", b =>
                {
                    b.HasOne("Rikkei.PindMind.DAO.Models.Space", "Space")
                        .WithMany("Users")
                        .HasForeignKey("SpaceID");
                });
#pragma warning restore 612, 618
        }
    }
}
