using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLHX.Server.Common.Migrations.Player
{
    /// <inheritdoc />
    public partial class FleetsDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Adv",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Fleets",
                table: "Players",
                type: "jsonb",
                nullable: false,
                defaultValue: "[{\"Id\":1,\"Name\":null,\"ShipLists\":[1,2],\"Commanders\":[]},{\"Id\":2,\"Name\":null,\"ShipLists\":[],\"Commanders\":[]},{\"Id\":11,\"Name\":null,\"ShipLists\":[],\"Commanders\":[]},{\"Id\":12,\"Name\":null,\"ShipLists\":[],\"Commanders\":[]}]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fleets",
                table: "Players");

            migrationBuilder.AlterColumn<string>(
                name: "Adv",
                table: "Players",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldDefaultValue: "");
        }
    }
}
