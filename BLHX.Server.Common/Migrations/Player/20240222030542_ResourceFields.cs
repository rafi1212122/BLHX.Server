using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLHX.Server.Common.Migrations.Player
{
    /// <inheritdoc />
    public partial class ResourceFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResourceFields",
                columns: table => new
                {
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerUid = table.Column<uint>(type: "INTEGER", nullable: false),
                    LastHarvestTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Level = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceFields", x => new { x.Type, x.PlayerUid });
                    table.ForeignKey(
                        name: "FK_ResourceFields_Players_PlayerUid",
                        column: x => x.PlayerUid,
                        principalTable: "Players",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceFields_PlayerUid",
                table: "ResourceFields",
                column: "PlayerUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceFields");
        }
    }
}
