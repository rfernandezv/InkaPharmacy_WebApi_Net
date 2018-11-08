using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InkaPharmacy.Api.Employee.Application.Dto;

namespace InkaPharmacy.Api.Employee.Application.Assembler
{
    using InkaPharmacy.Api.Employee.Domain.Entity;

    public class EmployeeAssembler
    {
        private readonly IMapper _mapper;

        public EmployeeAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Employee toEntity(EmployeeDto EmployeeLoginDto)
        {
            return _mapper.Map<Employee>(EmployeeLoginDto);
        }
    }

}
