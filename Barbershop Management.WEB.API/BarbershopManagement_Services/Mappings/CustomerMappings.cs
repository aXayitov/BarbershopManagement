using AutoMapper;
using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Services.DTOs.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.Mappings
{
    public class CustomerMappings : Profile
    {
        public CustomerMappings()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(x => x.FullName, r => r.MapFrom(e => GetFullName(e)));
            CreateMap<CustomerForCreateDto, Customer>();
            CreateMap<CustomerForUpdateDto, Customer>();
        }

        private string GetFullName(Customer customer)
        {
            if (customer.LastName == null)
            {
                return customer.FirstName;
            }

            return customer.FirstName + " " + customer.LastName;
        }
    }
}
