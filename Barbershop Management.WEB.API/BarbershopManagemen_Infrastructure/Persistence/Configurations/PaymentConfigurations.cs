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
    public class PaymentConfigurations : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable(nameof(Payment));
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Enrollment)
                .WithMany()
                .HasForeignKey(p => p.EnrollmentId);

            builder.Property(p => p.Amount)
                .HasColumnType("money")
                .IsRequired();
            builder.Property(p => p.PaymentDate)
                .IsRequired();
            builder.Property(p => p.PaymentType)
                .IsRequired();
        }
    }
}
