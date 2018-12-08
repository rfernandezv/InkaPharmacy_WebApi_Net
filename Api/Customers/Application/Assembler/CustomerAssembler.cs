using AutoMapper;
using InkaPharmacy.Api.Customers.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkaPharmacy.Api.Customers.Application.Assembler
{
    public class CustomerAssembler
    {
        private readonly IMapper _mapper;

        public CustomerAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public CustomerDto FromCustomerToCustomerDto(Customer customer)
        {
            return _mapper.Map<Customer, CustomerDto>(customer);
        }

        public Customer FromCustomerDtoToCustomer(CustomerDto customerDto)
        {
            return _mapper.Map<CustomerDto, Customer>(customerDto);
        }

        public List<CustomerDto> FromListCustomerToListCustomerDto(List<Customer> Customers)
        {
            return _mapper.Map<List<Customer>, List<CustomerDto>>(Customers);
        }

    }
}
