using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkaPharmacy.Api.Customers.Application.Dto
{
    public class CustomerDto
    {
        public  long Id { get; set; }
        public  string Name { get; set; }
        public  string Last_Name1 { get; set; }
        public  string Last_Name2 { get; set; }
        public  string Address { get; set; }
        public  string Telephone { get; set; }
        public  string Email { get; set; }
        public  string Document_Number { get; set; }
        public  int Status { get; set; }

    }
}
