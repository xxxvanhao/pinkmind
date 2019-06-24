
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rikkei.PinkMind.Migrator.Migrations
{
    public partial class fixIssueModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssueKey",
                table: "tbl_issue");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "tbl_reupdate",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectKey",
                table: "tbl_reupdate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpaceID",
                table: "tbl_reupdate",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectKey",
                table: "tbl_reupdate");

            migrationBuilder.DropColumn(
                name: "SpaceID",
                table: "tbl_reupdate");

            migrationBuilder.AlterColumn<string>(
                name: "UpdateTime",
                table: "tbl_reupdate",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "IssueKey",
                table: "tbl_issue",
                nullable: true);
        }
    }
}
