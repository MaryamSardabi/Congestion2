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
                new Calender() { Date = new DateTime(2013, 01, 01), IsHoliday = true, IsTollFree = true },
                new Calender() { Date = new DateTime(2013, 01, 02), IsHoliday = false, IsTollFree = true },
                new Calender() { Date = new DateTime(2013, 01, 03), IsHoliday = true, IsTollFree = false },
                new Calender() { Date = new DateTime(2013, 01, 04), IsHoliday = false, IsTollFree = false },
                new Calender() { Date = new DateTime(2013, 01, 05), IsHoliday = false, IsTollFree = false },
                new Calender() { Date = new DateTime(2013, 01, 06), IsHoliday = false, IsTollFree = false },
                new Calender() { Date = new DateTime(2013, 01, 07), IsHoliday = false, IsTollFree = false });
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
               new Car("No1111", "Emergency vehicles", EmergencyVehicles),
               new Car("No2222", "Diplomat vehicles", DiplomatVehicles),
               new Car("No3333", "Motorcycles", Motorcycles),
               new Car("No1111", "Busses", MilitaryVehicles),
               new Car("No2222", "Military vehicles", Ordinary),
               new Car("No3333", "Foreign vehicles", Ordinary));

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
