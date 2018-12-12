namespace InkaPharmacy.Api.Common.Application.Dto
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
