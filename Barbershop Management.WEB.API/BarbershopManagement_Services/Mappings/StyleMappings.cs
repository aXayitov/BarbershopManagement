using AutoMapper;
using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Services.DTOs.StyleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.Mappings
{
    public class StyleMappings : Profile
    {
        public StyleMappings() 
        {
            CreateMap<Style, StyleDto>();
            CreateMap<StyleForCreateDto, Style>();
            CreateMap<StyleForUpdateDto, Style>();
        }
    }
}
