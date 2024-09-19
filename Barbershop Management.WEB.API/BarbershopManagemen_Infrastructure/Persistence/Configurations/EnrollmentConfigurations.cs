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
    public class EnrollmentConfigurations : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable(nameof(Enrollment));
            builder.HasKey(e => e.Id);
                
            builder.HasOne(e => e.Employee)
                .WithMany(b => b.Enrollments)
                .HasForeignKey(e => e.EmployeeId);

            builder.HasOne(e => e.Customer)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CustomerId);
        }
    }
}
