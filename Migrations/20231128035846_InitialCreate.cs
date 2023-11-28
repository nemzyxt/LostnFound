using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LostnFound.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auth",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "LostItemModel",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateLost = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationLost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsClaimed = table.Column<bool>(type: "bit", nullable: false),
                    FinderId = table.Column<int>(type: "int", nullable: false),
                    DateFound = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationFound = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinderContact = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LostItemModel", x => x.ItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auth");

            migrationBuilder.DropTable(
                name: "LostItemModel");
        }
    }
}
