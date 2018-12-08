namespace InkaPharmacy.Api.Employees.Application.Dto
{
    public class EmployeeDto
    {
        public  long Id { get; set; }
        public  string Name { get; set; }
        public  string Last_name1 { get; set; }
        public  string Last_name2 { get; set; }
        public  string Address { get; set; }
        public  string Telephone { get; set; }
        public  long Role_id { get; set; }
        public  long Store_id { get; set; }
        public  string Username { get; set; }
        public  string Email { get; set; }
        public  int Status { get; set; }

        public EmployeeDto()
        {
        }



    }
}
