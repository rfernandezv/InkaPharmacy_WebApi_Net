using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using InkaPhatmacy.Api.Common.Application.Dto;
using System;
using InkaPhatmacy.Api.Common.Application;
using System.Linq;

namespace InkaPhatmacy.Api.Controllers
{
    using InkaPhatmacy.Api.Security.Application.Assembler;
    using InkaPhatmacy.Api.Security.Domain.Repository;
    using InkaPhatmacy.Api.Common.Domain.Specification;
    using System.Collections.Generic;

    using InkaPhatmacy.Api.Security.Infrastructure.Persistence.NHibernate.Specification;
    using System.Security.Claims;
    using System.IdentityModel.Tokens.Jwt;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;
    using InkaPhatmacy.Api.Common.Constantes;
    using InkaPhatmacy.Api.Empleado.Domain.Entity;
    using InkaPhatmacy.Api.Empleado.Application.Dto;

    [Route("api/Security/Login")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISecurityRepository _securityRepository;
        private readonly EmployeeAssembler _empleadoLoginAssembler;
        ResponseHandler responseHandler;

        public SecurityController(
            IUnitOfWork unitOfWork,
            ISecurityRepository securityRepository,
            EmployeeAssembler empleadoLoginAssembler)
        {
            _unitOfWork = unitOfWork;
            _securityRepository = securityRepository;
            _empleadoLoginAssembler = empleadoLoginAssembler;
            responseHandler = new ResponseHandler();
        }



        [HttpGet]
        public IActionResult Login([FromQuery]string usu, [FromQuery] string clave)
        {
            bool uowStatus = false;
            Notification notification = new Notification();
            Employee employee = new Employee();
            try
            {
                Specification<Employee> specification = GetLogingSpecification(usu, clave);
                uowStatus = _unitOfWork.BeginTransaction();
                List<Employee> empleados = _securityRepository.GetList(specification);
                _unitOfWork.Commit(uowStatus);

                if ( empleados.FirstOrDefault() == null)
                {
                    throw new ArgumentException("Employee doesn't logueado");
                }
           
                EmployeeDto empleadosDto = _empleadoLoginAssembler.toDto(empleados.FirstOrDefault());
                var token = GenerateToken(empleadosDto.Username);
                return Ok(this.responseHandler.getOkCommandResponse("bearer " + token, Constantes.HttpStatus.Success, empleadosDto));

            }
            catch (ArgumentException ex)
            {
                _unitOfWork.Rollback(uowStatus);
                return Unauthorized();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);                
                return StatusCode(StatusCodes.Status500InternalServerError, this.responseHandler.getAppExceptionResponse());
                
            }
        }

        private Specification<Employee> GetLogingSpecification(string usu, string clave )
        {
            Specification<Employee> specification = Specification<Employee>.All;
            specification = specification.And(new LoginBySpecification(usu, clave));
            return specification;
        }

        private string GenerateToken(string username)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            var TokenSecret = Environment.GetEnvironmentVariable("InkaPharmacyTokenSecret");
            Console.WriteLine(TokenSecret);

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenSecret)),
                                             SecurityAlgorithms.HmacSha256)),
                    new JwtPayload(claims));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
