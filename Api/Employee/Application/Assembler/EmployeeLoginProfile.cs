using AutoMapper;
using InkaPharmacy.Api.Employee.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkaPharmacy.Api.Employee.Application.Assembler
{
    using InkaPharmacy.Api.Employee.Domain.Entity;

    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee , EmployeeDto>()
               /* .ForMember(
                    dest => dest.Id,
                    x => x.MapFrom(src => src.ci)
                )
                .ForMember(
                    dest => dest.nombre,
                    x => x.MapFrom(src => src.nombre)
                )
               .ForMember(
                    dest => dest.paterno,
                    x => x.MapFrom(src => src.paterno)
                )
             .ForMember(
                    dest => dest.materno,
                    x => x.MapFrom(src => src.materno)
                )
                 .ForMember(
                    dest => dest.direccion,
                    x => x.MapFrom(src => src.direccion)
                )
                .ForMember(
                    dest => dest.telefono,
                    x => x.MapFrom(src => src.telefono)
                )
                   .ForMember(
                    dest => dest.usu,
                    x => x.MapFrom(src => src.usu)
                )
                   .ForMember(
                    dest => dest.clave,
                    x => x.MapFrom(src => src.clave)
                )
                   .ForMember(
                    dest => dest.correo,
                    x => x.MapFrom(src => src.correo)
                )
                     .ForMember(
                    dest => dest.estado,
                    x => x.MapFrom(src => src.estado)
                )
                     .ForMember(
                    dest => dest.id_tienda,
                    x => x.MapFrom(src => src.id_tienda/*tienda.id_tienda)
                )
                 .ForMember(
                    dest => dest.id_perfil,
                    x => x.MapFrom(src => src.id_perfil/*perfil.id_perfil)
                )*/;




        }
    }
}
