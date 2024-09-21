using AutoMapper;
using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Services.DTOs.PaymentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.Mappings
{
    public class PaymentMappings : Profile
    {
        public PaymentMappings()
        {
            CreateMap<Payment, PaymentDto>()
                .ForMember(x => x.Service, r => r.MapFrom(e => e.Enrollment.Service.Name));
            CreateMap<PaymentForCreateDto, Payment>();
            CreateMap<PaymentForUpdateDto, Payment>();
        }
    }
}
