using AutoMapper;
using InkaPhatmacy.Api.Customers;
using InkaPhatmacy.Api.Customers.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkaPhatmacy.Api.Products.Application.Assembler
{
    using InkaPhatmacy.Api.Product ;
    using InkaPhatmacy.Api.Product.Application.Dto;

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
