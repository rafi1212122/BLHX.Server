using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLHX.Server.Common.Migrations.Player
{
    /// <inheritdoc />
    public partial class Players_AddParams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<uint>(
                name: "AccPayLv",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<string>(
                name: "Appreciation",
                table: "Players",
                type: "jsonb",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<uint>(
                name: "AttackCount",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "BuyOilCount",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<int>(
                name: "CardLists_Capacity",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CartoonCollectMarks",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CartoonReadMarks",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CdLists_Capacity",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Characters",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<uint>(
                name: "ChatMsgBanTime",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "ChatRoomId",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "ChildDisplay",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "CollectAttackCount",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "CommanderBagMax",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "EquipBagMax",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<string>(
                name: "FlagLists",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<uint>(
                name: "GmFlag",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "GuideIndex",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "GuildWaitTime",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "MarryShip",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "MaxRank",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<string>(
                name: "MedalIds",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<uint>(
                name: "PvpAttackCount",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "PvpWinCount",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<string>(
                name: "RandomShipLists",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<uint>(
                name: "RandomShipMode",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "Rank",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<int>(
                name: "RefundShopInfoLists_Capacity",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<uint>(
                name: "Rmb",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "ShipBagMax",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<string>(
                name: "Soundstories",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StoryLists",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TakingShipLists_Capacity",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<uint>(
                name: "ThemeUploadNotAllowedTime",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "WinCount",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.CreateTable(
                name: "Idtimeinfo",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Time = table.Column<uint>(type: "INTEGER", nullable: false),
                    PlayerUid = table.Column<uint>(type: "INTEGER", nullable: true),
                    PlayerUid1 = table.Column<uint>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idtimeinfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idtimeinfo_Players_PlayerUid",
                        column: x => x.PlayerUid,
                        principalTable: "Players",
                        principalColumn: "Uid");
                    table.ForeignKey(
                        name: "FK_Idtimeinfo_Players_PlayerUid1",
                        column: x => x.PlayerUid1,
                        principalTable: "Players",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Idtimeinfo_PlayerUid",
                table: "Idtimeinfo",
                column: "PlayerUid");

            migrationBuilder.CreateIndex(
                name: "IX_Idtimeinfo_PlayerUid1",
                table: "Idtimeinfo",
                column: "PlayerUid1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Idtimeinfo");

            migrationBuilder.DropColumn(
                name: "AccPayLv",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Appreciation",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "AttackCount",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "BuyOilCount",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CardLists_Capacity",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CartoonCollectMarks",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CartoonReadMarks",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CdLists_Capacity",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Characters",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ChatMsgBanTime",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ChatRoomId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ChildDisplay",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CollectAttackCount",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CommanderBagMax",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "EquipBagMax",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "FlagLists",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GmFlag",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GuideIndex",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GuildWaitTime",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "MarryShip",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "MaxRank",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "MedalIds",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PvpAttackCount",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PvpWinCount",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RandomShipLists",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RandomShipMode",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RefundShopInfoLists_Capacity",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Rmb",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ShipBagMax",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Soundstories",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "StoryLists",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TakingShipLists_Capacity",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ThemeUploadNotAllowedTime",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "WinCount",
                table: "Players");
        }
    }
}
