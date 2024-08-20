using BarbershopManagement_Domain.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagemen_Infrastructure.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
             new Role
             {
                 Id = "9d1e9b03-615e-4c76-a435-a09642f9efbe",
                 Name = "Visitor",
                 NormalizedName = "VISITOR",
                 Description = "User which does not need authentication."
             },
             new Role
             {
                 Id = "4449ff82-2344-4ff0-8e51-2587b0e744dd",
                 Name = "Admin",
                 NormalizedName = "ADMIN",
                 Description = "Administrator of the system."
             },
             new Role
             {
                 Id = "04e5249a-09f7-4f8b-8cca-6e6212d4879d",
                 Name = "Manager",
                 NormalizedName = "MANAGER",
                 Description = "Manager of Warehouse."
             });
        }
    }
}
