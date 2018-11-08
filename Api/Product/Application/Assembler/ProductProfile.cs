using AutoMapper;
using EnterprisePatterns.Api.Customers;
using EnterprisePatterns.Api.Customers.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterprisePatterns.Api.Products.Application.Assembler
{
    using EnterprisePatterns.Api.Product ;
    using EnterprisePatterns.Api.Product.Application.Dto;

    public class ProductProfile : Profile
    {

        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                //.ForMember(
                //    dest=> dest
                //)
                ;

            CreateMap<ProductDto, Product>();

        }

    }
}
