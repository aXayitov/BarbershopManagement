using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Domain.Entity.Identity
{
    public class Role : IdentityRole<string>
    {
        public string? Description { get; set; }
    }
}
