using CongestionDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Congestion.Infrastructure.Configuration
{
    public  class CalenderConfiguration : IEntityTypeConfiguration<Calender>
    {
        public void Configure(EntityTypeBuilder<Calender> builder)
        {
            builder.ToTable(nameof(Calender));
            builder.HasKey(x => x.Id);
            
        }       
    }
}
