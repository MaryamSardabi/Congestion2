using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Congestion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeSomeField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Car");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDateTime",
                table: "TollRegistration",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationDateTime",
                table: "TollRegistration");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
