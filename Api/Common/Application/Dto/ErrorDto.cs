using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkaPhatmacy.Api.Common.Application.Dto
{
    public class ErrorDto
    {
        public string message { get; set; }

        public ErrorDto()
        {
        }

        public ErrorDto(string message)
        {
            this.message = message;
        }

    }
}
