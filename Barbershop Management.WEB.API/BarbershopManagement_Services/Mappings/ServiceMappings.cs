using AutoMapper;
using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Services.DTOs.ServicesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.Mappings
{
    public class ServiceMappings : Profile
    {
        public ServiceMappings()
        {
            CreateMap<Service, ServiceDto>();
            CreateMap<ServiceForCreateDto, Service>();
            CreateMap<ServiceForUpdateDto, Service>();
        }
    }
}
