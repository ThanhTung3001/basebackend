using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations.ApplicationDb
{
    public partial class CustomerType_Migrations_NameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_customerTypes",
                table: "customerTypes");

            migrationBuilder.RenameTable(
                name: "customerTypes",
                newName: "CustomerTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerTypes",
                table: "CustomerTypes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerTypes",
                table: "CustomerTypes");

            migrationBuilder.RenameTable(
                name: "CustomerTypes",
                newName: "customerTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customerTypes",
                table: "customerTypes",
                column: "Id");
        }
    }
}
