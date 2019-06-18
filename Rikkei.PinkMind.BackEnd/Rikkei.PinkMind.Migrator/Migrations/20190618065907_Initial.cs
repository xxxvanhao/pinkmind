using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rikkei.PinkMind.Migrator.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CreateBy = table.Column<long>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<long>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    DelFlag = table.Column<bool>(type: "bit", nullable: false),
                    CheckUpdate = table.Column<byte[]>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_issuetype",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    BackgroundColor = table.Column<string>(nullable: false),
                    CreateBy = table.Column<long>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<long>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    DelFlag = table.Column<bool>(type: "bit", nullable: false),
                    CheckUpdate = table.Column<byte[]>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_issuetype", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_milestone",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CreateBy = table.Column<long>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<long>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    DelFlag = table.Column<bool>(type: "bit", nullable: false),
                    CheckUpdate = table.Column<byte[]>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_milestone", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_priority",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    CreateAt = table.Column<long>(nullable: false),
                    UpdateBy = table.Column<long>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    DelFlag = table.Column<bool>(type: "bit", nullable: false),
                    CheckUpdate = table.Column<byte[]>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_priority", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_project",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CreateBy = table.Column<long>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<long>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    DelFlag = table.Column<bool>(type: "bit", nullable: false),
                    CheckUpdate = table.Column<byte[]>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_project", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_resolution",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CreateBy = table.Column<long>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<long>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    DelFlag = table.Column<bool>(type: "bit", nullable: false),
                    CheckUpdate = table.Column<byte[]>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_resolution", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_reupdate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvatarPath = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    ActionName = table.Column<string>(nullable: true),
                    IssueKey = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_reupdate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_role",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_space",
                columns: table => new
                {
                    SpaceID = table.Column<string>(maxLength: 50, nullable: false),
                    OrganizationName = table.Column<string>(maxLength: 50, nullable: false),
                    CreateBy = table.Column<long>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<long>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    DelFlag = table.Column<bool>(type: "bit", nullable: false),
                    CheckUpdate = table.Column<byte[]>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_space", x => x.SpaceID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_status",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CreateBy = table.Column<long>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<long>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    DelFlag = table.Column<bool>(type: "bit", nullable: false),
                    CheckUpdate = table.Column<byte[]>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_status", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_team",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CreateBy = table.Column<long>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<long>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    DelFlag = table.Column<bool>(type: "bit", nullable: false),
                    CheckUpdate = table.Column<byte[]>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_team", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_version",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<int>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    DelFlag = table.Column<bool>(type: "bit", nullable: false),
                    CheckUpdate = table.Column<byte[]>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_version", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_spaceControl",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpaceID = table.Column<string>(nullable: false),
                    ControlBy = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_spaceControl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_spaceControl_tbl_space_SpaceID",
                        column: x => x.SpaceID,
                        principalTable: "tbl_space",
                        principalColumn: "SpaceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    PictureUrl = table.Column<string>(nullable: true),
                    SpaceID = table.Column<string>(maxLength: 50, nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_user_tbl_space_SpaceID",
                        column: x => x.SpaceID,
                        principalTable: "tbl_space",
                        principalColumn: "SpaceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_teamjoin",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamID = table.Column<int>(nullable: false),
                    ProjectID = table.Column<string>(nullable: true),
                    JoinOn = table.Column<DateTime>(nullable: false),
                    AddBy = table.Column<long>(nullable: true),
                    DelFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_teamjoin", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_teamjoin_tbl_project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "tbl_project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_teamjoin_tbl_team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "tbl_team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_issue",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IssueTypeID = table.Column<int>(nullable: false),
                    IssueKey = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StatusID = table.Column<int>(nullable: false),
                    AssigneeUser = table.Column<long>(nullable: true),
                    PriorityID = table.Column<int>(nullable: true),
                    CategoryID = table.Column<int>(nullable: true),
                    MilestoneID = table.Column<int>(nullable: true),
                    VersionID = table.Column<int>(nullable: true),
                    ResolutionID = table.Column<int>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    ProjectID = table.Column<string>(nullable: false),
                    CreateBy = table.Column<long>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<long>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    DelFlag = table.Column<bool>(type: "bit", nullable: false),
                    CheckUpdate = table.Column<byte[]>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_issue", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_issue_tbl_category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "tbl_category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_issue_tbl_issuetype_IssueTypeID",
                        column: x => x.IssueTypeID,
                        principalTable: "tbl_issuetype",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_issue_tbl_milestone_MilestoneID",
                        column: x => x.MilestoneID,
                        principalTable: "tbl_milestone",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_issue_tbl_priority_PriorityID",
                        column: x => x.PriorityID,
                        principalTable: "tbl_priority",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_issue_tbl_project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "tbl_project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_issue_tbl_resolution_ResolutionID",
                        column: x => x.ResolutionID,
                        principalTable: "tbl_resolution",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_issue_tbl_status_StatusID",
                        column: x => x.StatusID,
                        principalTable: "tbl_status",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_issue_tbl_version_VersionID",
                        column: x => x.VersionID,
                        principalTable: "tbl_version",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_teamdetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<long>(nullable: false),
                    TeamID = table.Column<int>(nullable: true),
                    RoleID = table.Column<int>(nullable: false),
                    JoinedOn = table.Column<DateTime>(nullable: false),
                    AddBy = table.Column<long>(nullable: true),
                    DelFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_teamdetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_teamdetail_tbl_role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "tbl_role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_teamdetail_tbl_team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "tbl_team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_teamdetail_tbl_user_UserID",
                        column: x => x.UserID,
                        principalTable: "tbl_user",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_comment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    CreateBy = table.Column<long>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<long>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    DelFlag = table.Column<bool>(type: "bit", nullable: false),
                    CheckUpdate = table.Column<byte[]>(type: "timestamp", nullable: false),
                    IssueID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_comment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_comment_tbl_issue_IssueID",
                        column: x => x.IssueID,
                        principalTable: "tbl_issue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_notify",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<long>(nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IssueID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_notify", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_notify_tbl_issue_IssueID",
                        column: x => x.IssueID,
                        principalTable: "tbl_issue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_file",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilePath = table.Column<string>(maxLength: 50, nullable: false),
                    CreateBy = table.Column<long>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<long>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    DelFlag = table.Column<bool>(type: "bit", nullable: false),
                    CheckUpdate = table.Column<byte[]>(type: "timestamp", nullable: false),
                    IssueID = table.Column<int>(nullable: false),
                    CommentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_file", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_file_tbl_comment_CommentID",
                        column: x => x.CommentID,
                        principalTable: "tbl_comment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_file_tbl_issue_IssueID",
                        column: x => x.IssueID,
                        principalTable: "tbl_issue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_comment_IssueID",
                table: "tbl_comment",
                column: "IssueID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_file_CommentID",
                table: "tbl_file",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_file_IssueID",
                table: "tbl_file",
                column: "IssueID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_issue_CategoryID",
                table: "tbl_issue",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_issue_IssueTypeID",
                table: "tbl_issue",
                column: "IssueTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_issue_MilestoneID",
                table: "tbl_issue",
                column: "MilestoneID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_issue_PriorityID",
                table: "tbl_issue",
                column: "PriorityID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_issue_ProjectID",
                table: "tbl_issue",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_issue_ResolutionID",
                table: "tbl_issue",
                column: "ResolutionID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_issue_StatusID",
                table: "tbl_issue",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_issue_VersionID",
                table: "tbl_issue",
                column: "VersionID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_notify_IssueID",
                table: "tbl_notify",
                column: "IssueID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_spaceControl_SpaceID",
                table: "tbl_spaceControl",
                column: "SpaceID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_teamdetail_RoleID",
                table: "tbl_teamdetail",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_teamdetail_TeamID",
                table: "tbl_teamdetail",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_teamdetail_UserID",
                table: "tbl_teamdetail",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_teamjoin_ProjectID",
                table: "tbl_teamjoin",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_teamjoin_TeamID",
                table: "tbl_teamjoin",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_SpaceID",
                table: "tbl_user",
                column: "SpaceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_file");

            migrationBuilder.DropTable(
                name: "tbl_notify");

            migrationBuilder.DropTable(
                name: "tbl_reupdate");

            migrationBuilder.DropTable(
                name: "tbl_spaceControl");

            migrationBuilder.DropTable(
                name: "tbl_teamdetail");

            migrationBuilder.DropTable(
                name: "tbl_teamjoin");

            migrationBuilder.DropTable(
                name: "tbl_comment");

            migrationBuilder.DropTable(
                name: "tbl_role");

            migrationBuilder.DropTable(
                name: "tbl_user");

            migrationBuilder.DropTable(
                name: "tbl_team");

            migrationBuilder.DropTable(
                name: "tbl_issue");

            migrationBuilder.DropTable(
                name: "tbl_space");

            migrationBuilder.DropTable(
                name: "tbl_category");

            migrationBuilder.DropTable(
                name: "tbl_issuetype");

            migrationBuilder.DropTable(
                name: "tbl_milestone");

            migrationBuilder.DropTable(
                name: "tbl_priority");

            migrationBuilder.DropTable(
                name: "tbl_project");

            migrationBuilder.DropTable(
                name: "tbl_resolution");

            migrationBuilder.DropTable(
                name: "tbl_status");

            migrationBuilder.DropTable(
                name: "tbl_version");
        }
    }
}
