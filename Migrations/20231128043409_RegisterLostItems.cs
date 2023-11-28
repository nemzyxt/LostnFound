using Microsoft.EntityFrameworkCore.Migrations;

namespace LostnFound.Migrations
{
    public partial class RegisterLostItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LostItemModel",
                table: "LostItemModel");

            migrationBuilder.RenameTable(
                name: "LostItemModel",
                newName: "LostItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LostItems",
                table: "LostItems",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LostItems",
                table: "LostItems");

            migrationBuilder.RenameTable(
                name: "LostItems",
                newName: "LostItemModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LostItemModel",
                table: "LostItemModel",
                column: "ItemId");
        }
    }
}
