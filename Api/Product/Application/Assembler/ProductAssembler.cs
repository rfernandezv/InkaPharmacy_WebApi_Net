using AutoMapper;
using InkaPharmacy.Api.Product.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkaPharmacy.Api.Products.Application.Assembler
{
    using InkaPharmacy.Api.Product;

    public class ProductAssembler
    {
        private readonly IMapper _mapper;

        public ProductAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ProductDto FromProductToProductDto(Product Product)
        {
            return _mapper.Map<Product, ProductDto>(Product);
        }

        public Product FromProductDtoToProduct(ProductDto ProductDto)
        {
            return _mapper.Map<ProductDto, Product>(ProductDto);
        }

        public ProductDto FromListProductToListProductDto(Product Product)
        {
            return _mapper.Map<Product, ProductDto>(Product);
        }

        public List<Product> FromListProductDtoToListProduct( List<ProductDto> ProductDto)
        {
            return _mapper.Map< List<ProductDto>, List<Product>>(ProductDto);
        }

        public List<ProductDto> FromListProductToListProductDto(List<Product> Product)
        {
            return _mapper.Map<List<Product>, List<ProductDto>>(Product);
        }

    }
}
