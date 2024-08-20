using BarbershopManagement_Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagemen_Infrastructure.Persistence
{
    public class BarbershopDbContext(DbContextOptions<BarbershopDbContext> options) : DbContext(options)
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Barber> Barbers { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
