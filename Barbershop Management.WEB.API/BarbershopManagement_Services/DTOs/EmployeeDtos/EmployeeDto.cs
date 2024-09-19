using BarbershopManagement_Services.DTOs.EnrollmentDtos;

namespace BarbershopManagement_Services.DTOs.BarberDtos
{
    public class EmployeeDto
    {
        public int Id { get; init; }
        public string FullName { get; init; }
        public string PhoneNumber { get; init; }
        public int PositionId { get; init; }
        public string Position { get; init; }
        public ICollection<EnrollmentDto> Enrollments { get; init; }
    }
}
