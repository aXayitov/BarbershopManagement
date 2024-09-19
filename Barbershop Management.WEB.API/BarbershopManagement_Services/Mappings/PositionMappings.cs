using AutoMapper;
using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Services.DTOs.PositionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.Mappings
{
    public class PositionMappings : Profile
    {
        public PositionMappings() 
        {
            CreateMap<Position, PositionDto>();
            CreateMap<PositionForCreateDto, Position>();
            CreateMap<PositionForUpdateDto, Position>();
        }
    }
}
