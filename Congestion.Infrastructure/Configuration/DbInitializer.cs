using CongestionDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Congestion.Infrastructure.Configuration
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            var city = new City("Gothenburg");
            modelBuilder.Entity<City>().HasData(city);

            modelBuilder.Entity<TimeToll>().HasData(
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

            modelBuilder.Entity<CongestionPlace>().HasData(
                new CongestionPlace("place1"),
                new CongestionPlace("place2"),
                new CongestionPlace("place3"),
                new CongestionPlace("place4"));

            modelBuilder.Entity<Calender>().HasData(
                new Calender() {Id = 1, Date = new DateTime(2013, 01, 01), IsHoliday = true, IsTollExempDay = true },
                new Calender() {Id = 2, Date = new DateTime(2013, 01, 02), IsHoliday = false, IsTollExempDay = true },
                new Calender() {Id = 3, Date = new DateTime(2013, 01, 03), IsHoliday = true, IsTollExempDay = false },
                new Calender() {Id = 4, Date = new DateTime(2013, 01, 04), IsHoliday = false, IsTollExempDay = false },
                new Calender() {Id = 5, Date = new DateTime(2013, 01, 05), IsHoliday = false, IsTollExempDay = false },
                new Calender() {Id = 6, Date = new DateTime(2013, 01, 06), IsHoliday = false, IsTollExempDay = false },
                new Calender() {Id = 7, Date = new DateTime(2013, 01, 07), IsHoliday = false, IsTollExempDay = false });

            modelBuilder.Entity<Car>().HasData(
               new Car("No1111", "Emergency vehicles", true),
               new Car("No2222", "Diplomat vehicles", true),
               new Car("No3333", "Motorcycles", true),
               new Car("No1111", "Busses", true),
               new Car("No2222", "Military vehicles", true),
               new Car("No3333", "Foreign vehicles", true));

           


        }
    }


}
