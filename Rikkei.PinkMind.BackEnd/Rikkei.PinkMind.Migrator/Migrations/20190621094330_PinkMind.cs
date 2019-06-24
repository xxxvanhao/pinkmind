using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rikkei.PinkMind.Migrator.Migrations
{
    public partial class PinkMind : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "UpdateBy",
                table: "tbl_version",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "CreateBy",
                table: "tbl_version",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "AddBy",
                table: "tbl_teamdetail",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "CreateBy",
                table: "tbl_priority",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "tbl_priority",
                nullable: false,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UpdateBy",
                table: "tbl_version",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "CreateBy",
                table: "tbl_version",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "AddBy",
                table: "tbl_teamdetail",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreateBy",
                table: "tbl_priority",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "CreateAt",
                table: "tbl_priority",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
