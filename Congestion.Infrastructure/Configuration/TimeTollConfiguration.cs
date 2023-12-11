using CongestionDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Congestion.Infrastructure.Configuration
{
    internal class TimeTollConfiguration : IEntityTypeConfiguration<TimeToll>
    {
        public void Configure(EntityTypeBuilder<TimeToll> builder)
        {
            builder.ToTable(nameof(TimeToll));
            builder.HasKey(x => x.Id);
        }
       
    }
}
