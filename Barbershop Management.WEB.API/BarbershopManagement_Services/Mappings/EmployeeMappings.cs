using AutoMapper;
using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Services.DTOs.BarberDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.Mappings
{
    public class EmployeeMappings : Profile
    {
        public EmployeeMappings() 
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(x => x.FullName, r => r.MapFrom(e => e.FirstName +" "+ e.LastName))
                .ForMember(x => x.Position, r => r.MapFrom(e => e.Position.Name));
            CreateMap<EmployeeForCreateDto, Position>();
            CreateMap<EmployeeForUpdateDto, Position>();
        }
      
    }
}
