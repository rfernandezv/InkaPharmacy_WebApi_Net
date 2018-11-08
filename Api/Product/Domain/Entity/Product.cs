using System;

namespace EnterprisePatterns.Api.Product
{
    public class Product
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Currency { get; set; }
        public virtual int Stock { get; set; }
        public virtual long Category_id { get; set; }
        public virtual string Lot_number { get; set; }
        public virtual string Sanitary_registration_number { get; set; }
        public virtual DateTime Registration_date { get; set; }
        public virtual DateTime Expiration_date { get; set; }
        public virtual int Status { get; set; }
        public virtual int Stock_status { get; set; }
        
        public Product()
        {
        }

    }
}
