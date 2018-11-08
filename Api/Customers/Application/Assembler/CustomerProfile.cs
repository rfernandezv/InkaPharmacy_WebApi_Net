using AutoMapper;
using InkaPharmacy.Api.Customers.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkaPharmacy.Api.Customers.Application.Assembler
{
    public class CustomerProfile : Profile
    {

        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                //.ForMember(
                //    dest=> dest
                //)
                ;

            CreateMap<CustomerDto, Customer>();

        }

    }
}
