using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLHX.Server.Common.Migrations.Player
{
    /// <inheritdoc />
    public partial class AddManifesto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adv",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adv",
                table: "Players");
        }
    }
}
