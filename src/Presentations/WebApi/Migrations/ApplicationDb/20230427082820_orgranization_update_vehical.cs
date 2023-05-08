using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations.ApplicationDb
{
    public partial class orgranization_update_vehical : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCirculation",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSeats",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfCirculation",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "NumberOfSeats",
                table: "Vehicles");
        }
    }
}
