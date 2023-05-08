using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations.ApplicationDb
{
    public partial class orgranization_update_email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebSiteAddress",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "WebSiteAddress",
                table: "Organizations");
        }
    }
}
