using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations.ApplicationDb
{
    public partial class orgranization_add_intro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Organizations",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "Organizations");

            migrationBuilder.AlterColumn<string>(
                name: "IsActive",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
