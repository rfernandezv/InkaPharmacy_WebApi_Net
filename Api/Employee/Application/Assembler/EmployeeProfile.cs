using AutoMapper;
using InkaPharmacy.Api.Employees.Application.Dto;

namespace InkaPharmacy.Api.Employees.Application.Assembler
{
    using InkaPharmacy.Api.Employees.Domain.Entity;

    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
