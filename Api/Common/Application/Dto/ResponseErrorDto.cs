using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkaPharmacy.Api.Common.Application.Dto
{
    public class ResponseErrorDto
    {
        public int httpStatus { get; set; }
        public List<ErrorDto> errors { get; set; }

        public ResponseErrorDto()
        {
        }

        public ResponseErrorDto(List<ErrorDto> errors)
        {
            this.errors = errors;
        }
    }
}
