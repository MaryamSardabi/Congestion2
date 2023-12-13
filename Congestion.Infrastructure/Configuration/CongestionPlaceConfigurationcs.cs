using CongestionDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congestion.Infrastructure.Configuration
{
    public class CongestionPlaceConfigurationcs : IEntityTypeConfiguration<CongestionPlace>
    {
        public void Configure(EntityTypeBuilder<CongestionPlace> builder)
        {
            builder.ToTable(nameof(CongestionPlace));
            builder.HasKey(x => x.Id);
            builder.HasMany(h => h.TollRegistrations).WithOne(w => w.CongestionPlace).OnDelete(DeleteBehavior.NoAction);
        }
      
    }
}
