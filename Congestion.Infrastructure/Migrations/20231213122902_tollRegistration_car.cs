using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Congestion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tollRegistration_car : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TollRegistration_Car_CarId",
                table: "TollRegistration");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "TollRegistration");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "TollRegistration",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TollRegistration_Car_CarId",
                table: "TollRegistration",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TollRegistration_Car_CarId",
                table: "TollRegistration");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "TollRegistration",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "TollRegistration",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TollRegistration_Car_CarId",
                table: "TollRegistration",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id");
        }
    }
}
