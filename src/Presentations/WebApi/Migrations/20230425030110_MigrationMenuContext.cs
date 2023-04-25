using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class MigrationMenuContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationMenuRole_ApplicationMenu_MenuId",
                schema: "Identity",
                table: "ApplicationMenuRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationMenu",
                schema: "Identity",
                table: "ApplicationMenu");

            migrationBuilder.RenameTable(
                name: "ApplicationMenu",
                schema: "Identity",
                newName: "Menu",
                newSchema: "Identity");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                schema: "Identity",
                table: "Menu",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                schema: "Identity",
                table: "Menu",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ParentId",
                schema: "Identity",
                table: "Menu",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationMenuRole_Menu_MenuId",
                schema: "Identity",
                table: "ApplicationMenuRole",
                column: "MenuId",
                principalSchema: "Identity",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationMenuRole_Menu_MenuId",
                schema: "Identity",
                table: "ApplicationMenuRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Menu_ParentId",
                schema: "Identity",
                table: "Menu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
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

            migrationBuilder.RenameTable(
                name: "Menu",
                schema: "Identity",
                newName: "ApplicationMenu",
                newSchema: "Identity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationMenu",
                schema: "Identity",
                table: "ApplicationMenu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationMenuRole_ApplicationMenu_MenuId",
                schema: "Identity",
                table: "ApplicationMenuRole",
                column: "MenuId",
                principalSchema: "Identity",
                principalTable: "ApplicationMenu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
