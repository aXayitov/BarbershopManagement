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
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));
            builder.HasKey(x => x.Id);

            builder.HasMany(c => c.Enrollments)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);

            builder.Property(c => c.FirstName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(c => c.LastName)
                .HasMaxLength(100)
                .IsRequired(false);
            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(c => c.Email)
                .HasMaxLength(150)
                .IsRequired(false);
        }
    }
}
