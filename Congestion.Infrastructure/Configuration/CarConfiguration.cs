using CongestionDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Congestion.Infrastructure.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {

            builder.ToTable(nameof(Car));
            builder.HasKey(x => x.Id).HasName("CarId");
        }
    }
}
