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
    public class BarberMappings : Profile
    {
        public BarberMappings() 
        {
            CreateMap<Barber, BarberDto>()
                .ForMember(x => x.FullName, r => r.MapFrom(e => e.FirstName + e.LastName));
            CreateMap<BarberForCreateDto, Barber>();
            CreateMap<BarberForUpdateDto, Barber>();
        }
        private string GetFullName(Barber barber)
        {
            if(barber.LastName == null)
            {
                return barber.FirstName;
            }

            return barber.FirstName + " " + barber.LastName;
        }
    }
}
