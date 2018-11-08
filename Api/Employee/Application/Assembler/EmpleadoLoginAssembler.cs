using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EnterprisePatterns.Api.Empleado.Application.Dto;

namespace EnterprisePatterns.Api.Empleado.Application.Assembler
{
    using EnterprisePatterns.Api.Empleado.Domain.Entity;

    public class EmployeeAssembler
    {
        private readonly IMapper _mapper;

        public EmployeeAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Employee toEntity(EmployeeDto empleadoLoginDto)
        {
            return _mapper.Map<Employee>(empleadoLoginDto);
        }
    }

}
