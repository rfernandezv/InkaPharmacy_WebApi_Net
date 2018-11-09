using AutoMapper;
using InkaPharmacy.Api.Employees.Application.Dto;

namespace InkaPharmacy.Api.Employees.Application.Assembler
{
    using InkaPharmacy.Api.Employees.Domain.Entity;

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
