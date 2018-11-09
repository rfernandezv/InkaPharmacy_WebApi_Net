using AutoMapper;
using InkaPharmacy.Api.Employees.Application.Dto;
using InkaPharmacy.Api.Employees.Domain.Entity;
using System.Collections.Generic;

namespace InkaPharmacy.Api.Employees.Application.Assembler
{


    public class EmployeeAssembler
    {
        private readonly IMapper _mapper;

        public EmployeeAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Employee toEntity(EmployeeDto EmployeeDto)
        {
            return _mapper.Map<Employee>(EmployeeDto);
        }

        public EmployeeDto toDto(Employee employee)
        {
            return _mapper.Map<EmployeeDto>(employee);
        }

        public List<EmployeeDto> toDtoList(List<Employee> employeeList)
        {
            return _mapper.Map<List<Employee>, List<EmployeeDto>>((List<Employee>)employeeList);
        }
    }

}
