using AutoMapper;
using InkaPharmacy.Api.Customers;
using InkaPharmacy.Api.Customers.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkaPharmacy.Api.Products.Application.Assembler
{
    using InkaPharmacy.Api.Product ;
    using InkaPharmacy.Api.Product.Application.Dto;

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
