using BarbershopManagement_Services.DTOs.EnrollmentDtos;

namespace BarbershopManagement_Services.DTOs.BarberDtos
{
    public class BarberDto
    {
        public int Id { get; init; }
        public string FullName { get; init; }
        public string PhoneNumber { get; init; }
        public ICollection<EnrollmentDto> Enrollments { get; init; }
    }
}
