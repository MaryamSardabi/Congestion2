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
                new Calender() {  Date = new DateTime(2013, 01, 01), IsHoliday = true, IsTollExempDay = true },
                new Calender() {  Date = new DateTime(2013, 01, 02), IsHoliday = false, IsTollExempDay = true },
                new Calender() {  Date = new DateTime(2013, 01, 03), IsHoliday = true, IsTollExempDay = false },
                new Calender() {  Date = new DateTime(2013, 01, 04), IsHoliday = false, IsTollExempDay = false },
                new Calender() {  Date = new DateTime(2013, 01, 05), IsHoliday = false, IsTollExempDay = false },
                new Calender() {  Date = new DateTime(2013, 01, 06), IsHoliday = false, IsTollExempDay = false },
                new Calender() {  Date = new DateTime(2013, 01, 07), IsHoliday = false, IsTollExempDay = false });
            }

            if (!dbContext.Cars.Any())
            {
                dbContext.Cars.FromSqlRaw("SET IDENTITY_INSERT [dbo].[Car] ON");
                dbContext.Cars.AddRange(
               new Car("No1111", "Emergency vehicles", true),
               new Car("No2222", "Diplomat vehicles", true),
               new Car("No3333", "Motorcycles", true),
               new Car("No1111", "Busses", true),
               new Car("No2222", "Military vehicles", true),
               new Car("No3333", "Foreign vehicles", true));

            }
            dbContext.SaveChanges();

            dbContext.Cities.FromSqlRaw("SET IDENTITY_INSERT [dbo].[City] Off");
            dbContext.TimeTolls.FromSqlRaw("SET IDENTITY_INSERT [dbo].[TimeToll] OFF");
            dbContext.CongestionPlaces.FromSqlRaw("SET IDENTITY_INSERT [dbo].[CongestionPlace] OFF");
            dbContext.TimeTolls.FromSqlRaw("SET IDENTITY_INSERT [dbo].[Calender] OFF");
            dbContext.TimeTolls.FromSqlRaw("SET IDENTITY_INSERT [dbo].[Car] Off");

        }
    }

}
