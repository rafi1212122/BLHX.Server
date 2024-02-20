using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLHX.Server.Common.Migrations.Player
{
    /// <inheritdoc />
    public partial class Init_PlayerContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Uid = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Token = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Level = table.Column<uint>(type: "INTEGER", nullable: false),
                    Exp = table.Column<uint>(type: "INTEGER", nullable: false),
                    DisplayInfo = table.Column<string>(type: "jsonb", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false),
                    PlayerUid = table.Column<uint>(type: "INTEGER", nullable: false),
                    Num = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => new { x.Id, x.PlayerUid });
                    table.ForeignKey(
                        name: "FK_Resources_Players_PlayerUid",
                        column: x => x.PlayerUid,
                        principalTable: "Players",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TemplateId = table.Column<uint>(type: "INTEGER", nullable: false),
                    Level = table.Column<uint>(type: "INTEGER", nullable: false),
                    Exp = table.Column<uint>(type: "INTEGER", nullable: false),
                    EquipInfoLists = table.Column<string>(type: "jsonb", nullable: false),
                    Energy = table.Column<uint>(type: "INTEGER", nullable: false),
                    State = table.Column<string>(type: "jsonb", nullable: false),
                    IsLocked = table.Column<bool>(type: "INTEGER", nullable: false),
                    TransformLists = table.Column<string>(type: "jsonb", nullable: false),
                    SkillIdLists = table.Column<string>(type: "jsonb", nullable: false),
                    Intimacy = table.Column<uint>(type: "INTEGER", nullable: false),
                    Proficiency = table.Column<uint>(type: "INTEGER", nullable: false),
                    StrengthLists = table.Column<string>(type: "jsonb", nullable: false),
                    SkinId = table.Column<uint>(type: "INTEGER", nullable: false),
                    Propose = table.Column<uint>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CommanderId = table.Column<uint>(type: "INTEGER", nullable: false),
                    BluePrintFlag = table.Column<uint>(type: "INTEGER", nullable: false),
                    CommonFlag = table.Column<uint>(type: "INTEGER", nullable: true),
                    ActivityNpc = table.Column<uint>(type: "INTEGER", nullable: false),
                    MetaRepairLists = table.Column<string>(type: "jsonb", nullable: false),
                    CoreLists = table.Column<string>(type: "jsonb", nullable: false),
                    PlayerUid = table.Column<uint>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastChangeName = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ships_Players_PlayerUid",
                        column: x => x.PlayerUid,
                        principalTable: "Players",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_Token",
                table: "Players",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resources_PlayerUid",
                table: "Resources",
                column: "PlayerUid");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_PlayerUid",
                table: "Ships",
                column: "PlayerUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
