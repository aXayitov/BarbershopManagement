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
                .ForMember(dto => dto.Customer, e => e.MapFrom(r => r.Customer.FirstName +" "+ r.Customer.LastName))
                .ForMember(dto => dto.Employee, e => e.MapFrom(r => r.Employee.FirstName +" "+ r.Employee.LastName))
                .ForMember(dto => dto.Service,  e => e.MapFrom(r => r.Service.Name));
            CreateMap<EnrollmentForCreateDto, Enrollment>();
            CreateMap<EnrollmentForUpdateDto, Enrollment>();
        }

    }
}
