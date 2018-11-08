namespace EnterprisePatterns.Api.Customers
{
    public class Customer
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Last_Name1 { get; set; }
        public virtual string Last_Name2 { get; set; }
        public virtual string Address { get; set; }
        public virtual string Telephone { get; set; }
        public virtual string Email { get; set; }
        public virtual string Document_Number { get; set; }
        public virtual int Status { get; set; }
        
        public Customer()
        {
        }

    }
}
