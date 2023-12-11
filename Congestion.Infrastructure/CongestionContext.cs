using Congestion.Infrastructure.Configuration;
using CongestionDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Congestion.Infrastructure
{
    public class CongestionContext : DbContext
    {
        public CongestionContext(DbContextOptions<CongestionContext> options) : base(options)
        {

        }

        public DbSet<Calender> Calenders { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CongestionPlace> CongestionPlaces { get; set; }
        public DbSet<TimeToll> TimeTolls { get; set; }
        public DbSet<TollRegistration> TollRegistrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new SeedingEntryConfiguration());

        }
    }


}
