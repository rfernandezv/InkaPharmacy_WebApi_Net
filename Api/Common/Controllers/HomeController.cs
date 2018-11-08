using InkaPhatmacy.Api.Common.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InkaPhatmacy.Api.Common.Controllers
{
    [Produces("application/json")]
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //[HttpGet]
        //public Object Get()
        //{
        //    return string.Empty; // new ApiStringResponseDto("api root endpoint");
        //}
    }
}
