using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Congestion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsHoliday = table.Column<bool>(type: "bit", nullable: false),
                    IsTollFree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTollFree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CarId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_CarTypes_CarTypeId",
                        column: x => x.CarTypeId,
                        principalTable: "CarTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CongestionPlace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongestionPlace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CongestionPlace_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeToll",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TollAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeToll", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeToll_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TollRegistration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    TimeTollId = table.Column<int>(type: "int", nullable: false),
                    CongestionPlaceId = table.Column<int>(type: "int", nullable: false),
                    CalenderId = table.Column<int>(type: "int", nullable: false),
                    TotalTollAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidTollAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TollRegistration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TollRegistration_Calender_CalenderId",
                        column: x => x.CalenderId,
                        principalTable: "Calender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TollRegistration_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TollRegistration_CongestionPlace_CongestionPlaceId",
                        column: x => x.CongestionPlaceId,
                        principalTable: "CongestionPlace",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TollRegistration_TimeToll_TimeTollId",
                        column: x => x.TimeTollId,
                        principalTable: "TimeToll",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarTypeId",
                table: "Car",
                column: "CarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CongestionPlace_CityId",
                table: "CongestionPlace",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeToll_CityId",
                table: "TimeToll",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TollRegistration_CalenderId",
                table: "TollRegistration",
                column: "CalenderId");

            migrationBuilder.CreateIndex(
                name: "IX_TollRegistration_CarId",
                table: "TollRegistration",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_TollRegistration_CongestionPlaceId",
                table: "TollRegistration",
                column: "CongestionPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_TollRegistration_TimeTollId",
                table: "TollRegistration",
                column: "TimeTollId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TollRegistration");

            migrationBuilder.DropTable(
                name: "Calender");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "CongestionPlace");

            migrationBuilder.DropTable(
                name: "TimeToll");

            migrationBuilder.DropTable(
                name: "CarTypes");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
