using CongestionDomain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congestion.Infrastructure.Configuration
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //seed for city
            migrationBuilder.InsertData(table: "City", columns: new[] { "Id", "Name" }, values: new object[] { 1, "Gothenburg" });

            //seed for timeToll
            migrationBuilder.InsertData(
                table: "TimeToll",
                columns: new[] { "Id", "CityId", "StartTime", "EndTime", "TollAmount" },
                values: new object[] { 1, 1, new TimeSpan(06, 00, 00), new TimeSpan(06, 29, 00), 8 });
            migrationBuilder.InsertData(
               table: "TimeToll",
               columns: new[] { "Id", "CityId", "StartTime", "EndTime", "TollAmount" },
               values: new object[] { 2, 1, new TimeSpan(06, 30, 00), new TimeSpan(06, 59, 00), 13 });
            migrationBuilder.InsertData(
               table: "TimeToll",
               columns: new[] { "Id", "CityId", "StartTime", "EndTime", "TollAmount" },
               values: new object[] { 3, 1, new TimeSpan(07, 00, 00), new TimeSpan(06, 59, 00), 18 });
            migrationBuilder.InsertData(
               table: "TimeToll",
               columns: new[] { "Id", "CityId", "StartTime", "EndTime", "TollAmount" },
               values: new object[] { 4, 1, new TimeSpan(08, 00, 00), new TimeSpan(08, 29, 00), 13 });
            migrationBuilder.InsertData(
               table: "TimeToll",
               columns: new[] { "Id", "CityId", "StartTime", "EndTime", "TollAmount" },
               values: new object[] { 5, 1, new TimeSpan(08, 30, 00), new TimeSpan(14, 59, 00), 8 });
            migrationBuilder.InsertData(
               table: "TimeToll",
               columns: new[] { "Id", "CityId", "StartTime", "EndTime", "TollAmount" },
               values: new object[] { 6, 1, new TimeSpan(15, 00, 00), new TimeSpan(15, 29, 00), 13 });
            migrationBuilder.InsertData(
               table: "TimeToll",
               columns: new[] { "Id", "CityId", "StartTime", "EndTime", "TollAmount" },
               values: new object[] { 7, 1, new TimeSpan(15, 30, 00), new TimeSpan(16, 59, 00), 18 });
            migrationBuilder.InsertData(
               table: "TimeToll",
               columns: new[] { "Id", "CityId", "StartTime", "EndTime", "TollAmount" },
               values: new object[] { 8, 1, new TimeSpan(17, 00, 00), new TimeSpan(17, 59, 00), 13 });
            migrationBuilder.InsertData(
              table: "TimeToll",
              columns: new[] { "Id", "CityId", "StartTime", "EndTime", "TollAmount" },
              values: new object[] { 9, 1, new TimeSpan(18, 00, 00), new TimeSpan(18, 29, 00), 8 });
            migrationBuilder.InsertData(
               table: "TimeToll",
               columns: new[] { "Id", "CityId", "StartTime", "EndTime", "TollAmount" },
               values: new object[] { 10, 1, new TimeSpan(18, 30, 00), new TimeSpan(05, 59, 00), 0 });

            //seed for congestionPlace
            migrationBuilder.InsertData(table: "CongestionPlace", columns: new[] { "Id", "Name" }, values: new object[] { 1, "place1" });
            migrationBuilder.InsertData(table: "CongestionPlace", columns: new[] { "Id", "Name" }, values: new object[] { 1, "place2" });
            migrationBuilder.InsertData(table: "CongestionPlace", columns: new[] { "Id", "Name" }, values: new object[] { 1, "place3" });
            migrationBuilder.InsertData(table: "CongestionPlace", columns: new[] { "Id", "Name" }, values: new object[] { 1, "place4" });

            //seed for calender
            migrationBuilder.InsertData(
               table: "Calender",
               columns: new[] { "Id", "Date", "IsHoliday", "IsTollExempDay" },
               values: new object[] { 1, new DateTime(2013, 01, 01), true, true });
            migrationBuilder.InsertData(
             table: "Calender",
             columns: new[] { "Id", "Date", "IsHoliday", "IsTollExempDay" },
             values: new object[] { 2, new DateTime(2013, 01, 02), false, true });
            migrationBuilder.InsertData(
             table: "Calender",
             columns: new[] { "Id", "Date", "IsHoliday", "IsTollExempDay" },
             values: new object[] { 3, new DateTime(2013, 01, 03), true, false });
            migrationBuilder.InsertData(
             table: "Calender",
             columns: new[] { "Id", "Date", "IsHoliday", "IsTollExempDay" },
             values: new object[] { 4, new DateTime(2013, 01, 04), false, false });
            migrationBuilder.InsertData(
             table: "Calender",
             columns: new[] { "Id", "Date", "IsHoliday", "IsTollExempDay" },
             values: new object[] { 5, new DateTime(2013, 01, 05), false, false });
            migrationBuilder.InsertData(
             table: "Calender",
             columns: new[] { "Id", "Date", "IsHoliday", "IsTollExempDay" },
             values: new object[] { 6, new DateTime(2013, 01, 06), false, false });
            migrationBuilder.InsertData(
             table: "Calender",
             columns: new[] { "Id", "Date", "IsHoliday", "IsTollExempDay" },
             values: new object[] { 7, new DateTime(2013, 01, 07), false, false });


            migrationBuilder.InsertData(
              table: "Car",
              columns: new[] { "CarId", "Tag", "Name", "IsTollIncluded" },
              values: new object[] { 1, "No1111", "Emergency vehicles", true });
            migrationBuilder.InsertData(
             table: "Car",
             columns: new[] { "CarId", "Tag", "Name", "IsTollIncluded" },
             values: new object[] { 2, "No2222", "Diplomat vehicles", true });
            migrationBuilder.InsertData(
             table: "Car",
             columns: new[] { "CarId", "Tag", "Name", "IsTollIncluded" },
             values: new object[] { 3, "No3333", "Motorcycles", true });
            migrationBuilder.InsertData(
             table: "Car",
             columns: new[] { "CarId", "Tag", "Name", "IsTollIncluded" },
             values: new object[] { 4, "No1111", "Busses", true });
            migrationBuilder.InsertData(
             table: "Car",
             columns: new[] { "CarId", "Tag", "Name", "IsTollIncluded" },
             values: new object[] { 5, "No2222", "Military vehicles", true });
            migrationBuilder.InsertData(
             table: "Car",
             columns: new[] { "CarId", "Tag", "Name", "IsTollIncluded" },
             values: new object[] { 6, "No3333", "Foreign vehicles", true });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TimeToll",
                keyColumn: "Id",
                keyValue: 1);
            migrationBuilder.DeleteData(
               table: "TimeToll",
               keyColumn: "Id",
               keyValue: 2);
            migrationBuilder.DeleteData(
               table: "TimeToll",
               keyColumn: "Id",
               keyValue: 3);
            migrationBuilder.DeleteData(
               table: "TimeToll",
               keyColumn: "Id",
               keyValue: 4);
            migrationBuilder.DeleteData(
               table: "TimeToll",
               keyColumn: "Id",
               keyValue: 5);
            migrationBuilder.DeleteData(
               table: "TimeToll",
               keyColumn: "Id",
               keyValue: 6);
            migrationBuilder.DeleteData(
               table: "TimeToll",
               keyColumn: "Id",
               keyValue: 7);
            migrationBuilder.DeleteData(
               table: "TimeToll",
               keyColumn: "Id",
               keyValue: 8);
            migrationBuilder.DeleteData(
               table: "TimeToll",
               keyColumn: "Id",
               keyValue: 9);
            migrationBuilder.DeleteData(
              table: "TimeToll",
              keyColumn: "Id",
              keyValue: 10);

            migrationBuilder.DeleteData(
              table: "CongestionPlace",
              keyColumn: "Id",
              keyValue: 1);
            migrationBuilder.DeleteData(
              table: "CongestionPlace",
              keyColumn: "Id",
              keyValue: 2);
            migrationBuilder.DeleteData(
              table: "CongestionPlace",
              keyColumn: "Id",
              keyValue: 3);
            migrationBuilder.DeleteData(
              table: "CongestionPlace",
              keyColumn: "Id",
              keyValue: 4);

            migrationBuilder.DeleteData(
              table: "Calender",
              keyColumn: "Id",
              keyValue: 1);
            migrationBuilder.DeleteData(
              table: "Calender",
              keyColumn: "Id",
              keyValue: 2);
            migrationBuilder.DeleteData(
              table: "Calender",
              keyColumn: "Id",
              keyValue: 3);
            migrationBuilder.DeleteData(
              table: "Calender",
              keyColumn: "Id",
              keyValue: 4);
            migrationBuilder.DeleteData(
              table: "Calender",
              keyColumn: "Id",
              keyValue: 5);
            migrationBuilder.DeleteData(
              table: "Calender",
              keyColumn: "Id",
              keyValue:6);
            migrationBuilder.DeleteData(
              table: "Calender",
              keyColumn: "Id",
              keyValue: 7);

            migrationBuilder.DeleteData(
              table: "Car",
              keyColumn: "CarId",
              keyValue: 1);
            migrationBuilder.DeleteData(
              table: "Car",
              keyColumn: "CarId",
              keyValue: 2);
            migrationBuilder.DeleteData(
              table: "Car",
              keyColumn: "CarId",
              keyValue: 3);
            migrationBuilder.DeleteData(
              table: "Car",
              keyColumn: "CarId",
              keyValue: 4);




        }
    }
}
