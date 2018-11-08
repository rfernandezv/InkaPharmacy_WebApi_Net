using EnterprisePatterns.Api.Common.Application.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterprisePatterns.Api.Common.Application.Dto
{
    public class RequestBaseDto
    {
        public RequestBodyType requestBodyType { get; set; }
    }
}
