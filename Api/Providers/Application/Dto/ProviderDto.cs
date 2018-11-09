namespace InkaPharmacy.Api.Providers.Application.Dto
{
    public class ProviderDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public int Status { get; set; }

        public ProviderDto()
        {
        }



    }
}
