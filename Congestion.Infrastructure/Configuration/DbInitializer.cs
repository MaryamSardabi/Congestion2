using CongestionDomain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Congestion.Infrastructure.Configuration
{
    public class DbInitializer
    {
        public static void Initialize(CongestionContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();

            var city = new City("Gothenburg");

            if (!dbContext.Cities.Any(o => o.Name == city.Name))
            {

                dbContext.Cities.FromSqlRaw("SET IDENTITY_INSERT [dbo].[City] ON");
                dbContext.Cities.Add(city);

            }

            if (!dbContext.TimeTolls.Any())
            {

                dbContext.TimeTolls.FromSqlRaw("SET IDENTITY_INSERT [dbo].[TimeToll] ON");
                dbContext.TimeTolls.AddRange(
                    new TimeToll(city, new TimeSpan(06, 00, 00), new TimeSpan(06, 29, 00), 8),
                    new TimeToll(city, new TimeSpan(06, 30, 00), new TimeSpan(06, 59, 00), 13),
                    new TimeToll(city, new TimeSpan(07, 00, 00), new TimeSpan(06, 59, 00), 18),
                    new TimeToll(city, new TimeSpan(08, 00, 00), new TimeSpan(08, 29, 00), 13),
                    new TimeToll(city, new TimeSpan(08, 30, 00), new TimeSpan(14, 59, 00), 8),
                    new TimeToll(city, new TimeSpan(15, 00, 00), new TimeSpan(15, 29, 00), 13),
                    new TimeToll(city, new TimeSpan(15, 30, 00), new TimeSpan(16, 59, 00), 18),
                    new TimeToll(city, new TimeSpan(17, 00, 00), new TimeSpan(17, 59, 00), 13),
                    new TimeToll(city, new TimeSpan(18, 00, 00), new TimeSpan(18, 29, 00), 8),
                    new TimeToll(city, new TimeSpan(18, 30, 00), new TimeSpan(05, 59, 00), 0));
            }

            if (!dbContext.CongestionPlaces.Any())
            {
                dbContext.CongestionPlaces.FromSqlRaw("SET IDENTITY_INSERT [dbo].[CongestionPlace] ON");

                dbContext.CongestionPlaces.AddRange(
                new CongestionPlace("place1", city),
                new CongestionPlace("place2", city),
                new CongestionPlace("place3", city),
                new CongestionPlace("place4", city)
                );

            }

            if (!dbContext.Calenders.Any())
            {
                dbContext.Calenders.FromSqlRaw("SET IDENTITY_INSERT [dbo].[Calender] ON");
                dbContext.Calenders.AddRange(
                new Calender() { Date = new DateTime(2013, 12, 01), IsHoliday = true, IsTollFree = true },
                new Calender() { Date = new DateTime(2013, 12, 02), IsHoliday = false, IsTollFree = true },
                new Calender() { Date = new DateTime(2013, 12, 03), IsHoliday = true, IsTollFree = false },
                new Calender() { Date = new DateTime(2013, 12, 04), IsHoliday = false, IsTollFree = false },
                new Calender() { Date = new DateTime(2013, 12, 05), IsHoliday = false, IsTollFree = false },
                new Calender() { Date = new DateTime(2013, 12, 06), IsHoliday = false, IsTollFree = false },
                new Calender() { Date = new DateTime(2013, 12, 07), IsHoliday = false, IsTollFree = false },
                new Calender() { Date = new DateTime(2013, 12, 08), IsHoliday = true, IsTollFree = true },
                new Calender() { Date = new DateTime(2013, 12, 09), IsHoliday = false, IsTollFree = true },
                new Calender() { Date = new DateTime(2013, 12, 10), IsHoliday = true, IsTollFree = false },
                new Calender() { Date = new DateTime(2013, 12, 11), IsHoliday = false, IsTollFree = false },
                new Calender() { Date = new DateTime(2013, 12, 12), IsHoliday = false, IsTollFree = false },
                new Calender() { Date = new DateTime(2013, 12, 13), IsHoliday = false, IsTollFree = false },
                new Calender() { Date = new DateTime(2013, 12, 14), IsHoliday = false, IsTollFree = false },
                new Calender() { Date = new DateTime(2013, 12, 15), IsHoliday = true, IsTollFree = true },
                new Calender() { Date = new DateTime(2013, 12, 16), IsHoliday = false, IsTollFree = true },
                new Calender() { Date = new DateTime(2013, 12, 17), IsHoliday = true, IsTollFree = false },
                new Calender() { Date = new DateTime(2013, 12, 18), IsHoliday = false, IsTollFree = false },
                new Calender() { Date = new DateTime(2013, 12, 19), IsHoliday = false, IsTollFree = false },
                new Calender() { Date = new DateTime(2013, 12, 20), IsHoliday = false, IsTollFree = false },
                new Calender() { Date = new DateTime(2013, 12, 21), IsHoliday = false, IsTollFree = false });
              
            }


            var EmergencyVehicles = new CarType("EmergencyVehicles", true);
            var DiplomatVehicles = new CarType("DiplomatVehicles ", true);
            var Motorcycles = new CarType("Motorcycles", true);
            var Busses = new CarType("Busses", true);
            var MilitaryVehicles = new CarType("MilitaryVehicles", true);
            var ForeignVehicles = new CarType("ForeignVehicles ", true);
            var Ordinary = new CarType("Ordinary", false);
            if (!dbContext.CarTypes.Any())
            {
                dbContext.CarTypes.FromSqlRaw("SET IDENTITY_INSERT [dbo].[CarType] ON");
                dbContext.CarTypes.AddRange(
                    EmergencyVehicles,
                    DiplomatVehicles,
                    Motorcycles,
                    Busses, MilitaryVehicles,
                    ForeignVehicles,
                    Ordinary);
            }

            if (!dbContext.Cars.Any())
            {
                dbContext.Cars.FromSqlRaw("SET IDENTITY_INSERT [dbo].[Car] ON");
                dbContext.Cars.AddRange(
               new Car("No1111", EmergencyVehicles),
               new Car("No2222", DiplomatVehicles),
               new Car("No3333", Motorcycles),
               new Car("No1111", MilitaryVehicles),
               new Car("No2222", Ordinary),
               new Car("No3333", Ordinary));

            }

            dbContext.SaveChanges();

            dbContext.Cities.FromSqlRaw("SET IDENTITY_INSERT [dbo].[City] Off");
            dbContext.TimeTolls.FromSqlRaw("SET IDENTITY_INSERT [dbo].[TimeToll] OFF");
            dbContext.CongestionPlaces.FromSqlRaw("SET IDENTITY_INSERT [dbo].[CongestionPlace] OFF");
            dbContext.TimeTolls.FromSqlRaw("SET IDENTITY_INSERT [dbo].[Calender] OFF");
            dbContext.CarTypes.FromSqlRaw("SET IDENTITY_INSERT [dbo].[CarType] ON");
            dbContext.TimeTolls.FromSqlRaw("SET IDENTITY_INSERT [dbo].[Car] Off");


        }
    }

}
