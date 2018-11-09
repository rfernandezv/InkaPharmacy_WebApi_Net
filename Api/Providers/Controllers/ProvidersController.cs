using InkaPharmacy.Api.Common.Application;
using InkaPharmacy.Api.Common.Application.Dto;
using InkaPharmacy.Api.Common.Domain.Specification;
using InkaPharmacy.Api.Providers.Application.Assembler;
using InkaPharmacy.Api.Providers.Application.Dto;
using InkaPharmacy.Api.Providers.Domain.Entity;
using InkaPharmacy.Api.Providers.Domain.Repository;
using InkaPharmacy.Api.Providers.Infrastructure.Persistence.NHibernate.Specification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InkaPharmacy.Api.Controllers
{


    [Authorize]
    [Route("api/Providers")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProviderRepository _providerRepository;
        private readonly ProviderAssembler _providerAssembler;
        public ResponseHandler _responseHandler;

        public ProvidersController(
            IUnitOfWork unitOfWork,
            IProviderRepository providerRepository,
            ProviderAssembler providerAssembler)
        {
            _unitOfWork = unitOfWork;
            _providerRepository = providerRepository;
            _providerAssembler = providerAssembler;
            _responseHandler = new ResponseHandler();
        }

        [HttpGet]
        public Object Get()
        {
            return new ApiStringResponseDto("api root endpoint");
        }

        [Route("/api/Providers/FindByDocumentNumber")]
        [HttpGet]
        public IActionResult FindByDocumentNumber([FromQuery] string DocumentNumber)
        {
            bool uowStatus = false;
            try
            {
                Provider provider = new Provider();
                Notification notification = provider.ValidateFindByDocumentNumber(DocumentNumber);

                if (notification.hasErrors())
                {
                    throw new ArgumentException(notification.errorMessage());
                }

                Specification<Provider> specification = GetFindByDocumentNumber(DocumentNumber);
                uowStatus = _unitOfWork.BeginTransaction();
                provider = _providerRepository.FindByDocumentNumber(specification);
                _unitOfWork.Commit(uowStatus);
                ProviderDto providersDto = _providerAssembler.FromProviderToProviderDto(provider);
                return StatusCode(StatusCodes.Status200OK, providersDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(_responseHandler.getAppCustomErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, this._responseHandler.getAppExceptionResponse());
            }
        }

        private Specification<Provider> GetFindByDocumentNumber(string DocumentNumber)
        {
            Specification<Provider> specification = Specification<Provider>.All;
            specification = specification.And(new FindByDocumentNumberBySpecification(DocumentNumber));
            return specification;
        }


    }
}
