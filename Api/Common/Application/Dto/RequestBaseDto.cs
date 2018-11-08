using InkaPharmacy.Api.Common.Application.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkaPharmacy.Api.Common.Application.Dto
{
    public class RequestBaseDto
    {
        public RequestBodyType requestBodyType { get; set; }
    }
}
