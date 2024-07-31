using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.DTOs.StyleDtos
{
    public class StyleDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public decimal Price { get; init; }
        public string ExecutionTime { get; init; }
    }
}
