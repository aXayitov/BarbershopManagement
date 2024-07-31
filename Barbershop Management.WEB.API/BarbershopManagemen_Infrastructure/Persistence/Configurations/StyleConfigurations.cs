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
    public class StyleConfigurations : IEntityTypeConfiguration<Style>
    {
        public void Configure(EntityTypeBuilder<Style> builder)
        {
            builder.ToTable(nameof(Style));
            builder.HasKey(x => x.Id);

            builder.Property(s => s.Name)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(s => s.Description)
                .HasMaxLength(500)
                .IsRequired(false);
            builder.Property(s => s.Price)
                .HasColumnType("money")
                .HasDefaultValue(0)
                .HasPrecision(18, 2);
            builder.Property(s => s.ExecutionTime)
                .IsRequired();
        }
    }
}
