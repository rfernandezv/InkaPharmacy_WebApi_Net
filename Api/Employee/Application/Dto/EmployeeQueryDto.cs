namespace InkaPharmacy.Api.Employees.Application.Dto
{
    public class EmployeeQueryDto
    {
        public  long Employee_Id { get; set; }
        public  string Name { get; set; }
        public  string Last_name1 { get; set; }
        public  string Last_name2 { get; set; }
        public  string Address { get; set; }
        public  string Telephone { get; set; }
        public string Role_name { get; set; }
        public string Store_name { get; set; }
        public  string Username { get; set; }
        public  string Email { get; set; }
        public  int Status { get; set; }

        public EmployeeQueryDto()
        {
        }



    }
}
