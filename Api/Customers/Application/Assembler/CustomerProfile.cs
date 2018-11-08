using AutoMapper;
using InkaPhatmacy.Api.Customers.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkaPhatmacy.Api.Customers.Application.Assembler
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
