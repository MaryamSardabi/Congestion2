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
    internal class TollRegistrationConfiguration : IEntityTypeConfiguration<TollRegistration>
    {
        public void Configure(EntityTypeBuilder<TollRegistration> builder)
        {
            builder.ToTable(nameof(TollRegistration));
            builder.HasKey(x => x.Id);
        }
    }
}
