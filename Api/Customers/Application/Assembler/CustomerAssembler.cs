using AutoMapper;
using EnterprisePatterns.Api.Customers.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterprisePatterns.Api.Customers.Application.Assembler
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

    }
}
