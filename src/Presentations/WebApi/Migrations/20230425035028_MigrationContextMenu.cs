using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class MigrationContextMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Menu_ParentId",
                schema: "Identity",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_ParentId",
                schema: "Identity",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "Identity",
                table: "Menu");

            migrationBuilder.AddColumn<int>(
                name: "ParrentId",
                schema: "Identity",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ParrentId",
                schema: "Identity",
                table: "Menu",
                column: "ParrentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Menu_ParrentId",
                schema: "Identity",
                table: "Menu",
                column: "ParrentId",
                principalSchema: "Identity",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Menu_ParrentId",
                schema: "Identity",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_ParrentId",
                schema: "Identity",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "ParrentId",
                schema: "Identity",
                table: "Menu");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                schema: "Identity",
                table: "Menu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ParentId",
                schema: "Identity",
                table: "Menu",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Menu_ParentId",
                schema: "Identity",
                table: "Menu",
                column: "ParentId",
                principalSchema: "Identity",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
