using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class MigrationUserMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountType",
                schema: "Identity",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastAccessAddress",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                schema: "Identity",
                table: "ApplicationMenu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                schema: "Identity",
                table: "ApplicationMenu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountType",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastAccessAddress",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                schema: "Identity",
                table: "ApplicationMenu");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                schema: "Identity",
                table: "ApplicationMenu");
        }
    }
}
