using BarbershopManagement_Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagemen_Infrastructure.Persistence.Configurations
{
    public class ServiceConfigurations : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable(nameof(Service));
            builder.HasKey(x => x.Id);

            builder.HasMany(s => s.Enrollments)
                .WithOne(e => e.Service)
                .HasForeignKey(e => e.ServiceId);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.Price)
                .HasColumnType("money")
                .IsRequired();
            builder.Property(x => x.Duration)
                .HasColumnType("time")
                .IsRequired(false);
        }
    }
}
