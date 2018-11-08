using AutoMapper;

namespace InkaPharmacy.Api.Security.Application.Assembler
{
    using InkaPharmacy.Api.Employee.Application.Dto;
    using InkaPharmacy.Api.Employee.Domain.Entity;
    using System.Collections.Generic;

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

        public EmployeeDto toDto(Employee employee)
        {
            return _mapper.Map<EmployeeDto>(employee);
        }

        public List<EmployeeDto> toDtoList(List<Employee> movieList)
        {
            return _mapper.Map<List<Employee>, List<EmployeeDto>>(movieList);
        }

    }
}
