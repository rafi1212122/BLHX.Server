using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLHX.Server.Common.Migrations.Player
{
    /// <inheritdoc />
    public partial class ChaptersDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<uint>(
                name: "CurrentChapter",
                table: "Players",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChapterInfoes",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false),
                    PlayerUid = table.Column<uint>(type: "INTEGER", nullable: false),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CellLists = table.Column<string>(type: "jsonb", nullable: false),
                    GroupLists = table.Column<string>(type: "jsonb", nullable: false),
                    AiLists = table.Column<string>(type: "jsonb", nullable: false),
                    EscortLists = table.Column<string>(type: "jsonb", nullable: false),
                    Round = table.Column<uint>(type: "INTEGER", nullable: false),
                    IsSubmarineAutoAttack = table.Column<bool>(type: "INTEGER", nullable: false),
                    OperationBuffs = table.Column<string>(type: "jsonb", nullable: false),
                    ModelActCount = table.Column<uint>(type: "INTEGER", nullable: false),
                    BuffLists = table.Column<string>(type: "jsonb", nullable: false),
                    LoopFlag = table.Column<uint>(type: "INTEGER", nullable: false),
                    ExtraFlagLists = table.Column<string>(type: "jsonb", nullable: false),
                    CellFlagLists = table.Column<string>(type: "jsonb", nullable: false),
                    ChapterHp = table.Column<uint>(type: "INTEGER", nullable: false),
                    ChapterStrategyLists = table.Column<string>(type: "jsonb", nullable: false),
                    KillCount = table.Column<uint>(type: "INTEGER", nullable: false),
                    InitShipCount = table.Column<uint>(type: "INTEGER", nullable: false),
                    ContinuousKillCount = table.Column<uint>(type: "INTEGER", nullable: false),
                    BattleStatistics = table.Column<string>(type: "jsonb", nullable: false),
                    FleetDuties = table.Column<string>(type: "jsonb", nullable: false),
                    MoveStepCount = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterInfoes", x => new { x.Id, x.PlayerUid });
                    table.ForeignKey(
                        name: "FK_ChapterInfoes_Players_PlayerUid",
                        column: x => x.PlayerUid,
                        principalTable: "Players",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChapterInfoes_PlayerUid",
                table: "ChapterInfoes",
                column: "PlayerUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChapterInfoes");

            migrationBuilder.DropColumn(
                name: "CurrentChapter",
                table: "Players");
        }
    }
}
