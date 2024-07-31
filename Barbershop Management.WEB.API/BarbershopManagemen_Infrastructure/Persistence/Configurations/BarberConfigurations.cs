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
    public class BarberConfigurations : IEntityTypeConfiguration<Barber>
    {
        public void Configure(EntityTypeBuilder<Barber> builder)
        {
            builder.ToTable(nameof(Barber));
            builder.HasKey(x => x.Id);

            builder.HasMany(b => b.Enrollments)
                .WithOne(e => e.Barber)
                .HasForeignKey(e => e.BarberId);

            builder.Property(x => x.FirstName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.LastName)
                .HasMaxLength(100)
                .IsRequired(false);
            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(150)
                .IsRequired();          
        }
    }
}
