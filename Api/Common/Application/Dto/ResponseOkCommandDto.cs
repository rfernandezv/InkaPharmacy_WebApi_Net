using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkaPharmacy.Api.Common.Application.Dto
{
    public class ResponseOkCommandDto
    {
        public int httpStatus { get; set; }
        public string message { get; set; }
        public object content { get; set; }
    }
}
