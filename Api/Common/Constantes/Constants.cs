using Microsoft.AspNetCore.Http;

namespace InkaPharmacy.Api.Common.Constants
{
    public class Constants
    {
        public class HttpStatus
        {
            public const int Success = StatusCodes.Status200OK;
            public const int Created = StatusCodes.Status201Created;
            public const int BadRequest = StatusCodes.Status400BadRequest;
            public const int ErrorServer = StatusCodes.Status500InternalServerError;
        }

        public class DefaultPagination
        {
            public const int defaultOffset = 1;
            public const int defaultLimit = 10;
            public const string orderBy = "Id";
            public const string orderDirection = "desc";

        }
    }
}
