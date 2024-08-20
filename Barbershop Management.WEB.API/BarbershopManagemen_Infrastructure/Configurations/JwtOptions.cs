using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagemen_Infrastructure.Configurations
{
    public class JwtOptions
    {
        public const string SectionName = "Jwt";

        [Required(ErrorMessage = "Secret Key is required.")]
        [MinLength(16, ErrorMessage = "Secret Key must have more than 16 characters.")]
        public required string SecretKey { get; init; }

        [Required(ErrorMessage = "Valid Audience is required.")]
        public required string ValidAudience { get; init; }

        [Required(ErrorMessage = "Valid Issuer is required.")]
        public required string ValidIssuer { get; init; }

        [Required(ErrorMessage = "Expires In is required.")]
        public required int ExpiresInMinutes { get; init; }

        [NotMapped]
        public DateTime Expires => DateTime.UtcNow.AddMinutes(ExpiresInMinutes);
    }
}
