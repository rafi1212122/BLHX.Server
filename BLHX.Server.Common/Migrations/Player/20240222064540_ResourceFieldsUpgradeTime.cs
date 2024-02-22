using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLHX.Server.Common.Migrations.Player
{
    /// <inheritdoc />
    public partial class ResourceFieldsUpgradeTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpgradeTime",
                table: "ResourceFields",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpgradeTime",
                table: "ResourceFields");
        }
    }
}
