using AutoMapper;
using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Services.DTOs.EnrollmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.Mappings
{
    public class EnrollmentMappings : Profile
    {
        public EnrollmentMappings() 
        {
            CreateMap<Enrollment, EnrollmentDto>()
                .ForMember(dto => dto.Customer, e => e.MapFrom(r => r.Customer.FirstName + r.Customer.LastName))
                .ForMember(dto => dto.Barber, e => e.MapFrom(r => r.Barber.FirstName + r.Barber.LastName));
            CreateMap<EnrollmentForCreateDto, Enrollment>();
            CreateMap<EnrollmentForUpdateDto, Enrollment>();
        }
        private string GetFullName(Customer customer)
        {
            if (customer.LastName == null)
            {
                return customer.FirstName;
            }

            return customer.FirstName + " " + customer.LastName;
        }
        private string GetFullName(Barber barber)
        {
            if (barber.LastName == null)
            {
                return barber.FirstName;
            }

            return barber.FirstName + " " + barber.LastName;
        }
    }
}
