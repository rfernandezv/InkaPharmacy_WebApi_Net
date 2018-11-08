using EnterprisePatterns.Api.Common.Application;
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

        public virtual Notification validateFindByProductName(string ProductName)
        {
            Notification notification = new Notification();

            if (string.IsNullOrEmpty(ProductName))
            {
                notification.addError("The Product Name is null");
            }

            return notification;
        }

        public virtual Notification validateFindByCategory(long Category_id)
        {
            Notification notification = new Notification();

            if (Category_id== 0)
            {
                notification.addError("The Category is null");
            }

            return notification;
        }

        public virtual Notification validateGetProductById(long ProductId)
        {
            Notification notification = new Notification();

            if (ProductId == 0)
            {
                notification.addError("The Product Id is null");
            }

            return notification;
        }

        public virtual Notification validateDeleteProduct(Product product)
        {
            Notification notification = new Notification();

            if (product == null)
            {
                notification.addError("The Product is null");
            }

            if (product.Id == 0)
            {
                notification.addError("The Product Id is null");
            }

            return notification;
        }


        public virtual Notification validateForSave(string action = "")
        {
            Notification notification = new Notification();

            if (this == null)
            {
                notification.addError("The Product is null");
            }

            if (action == "U")
            {
                if (this.Id == 0)
                {
                    notification.addError("The Product doesn´t have a valid Id");
                }
            }


            if (string.IsNullOrEmpty(this.Name))
            {
                notification.addError("The Product doesn´t have a valid Name");
            }

            if (this.Price == 0m)
            {
                notification.addError("The Product doesn´t have a valid Price");
            }

            if (string.IsNullOrEmpty(this.Currency))
            {
                notification.addError("The Product doesn´t have a valid Currency");
            }

            if (this.Stock == 0)
            {
                notification.addError("The Product doesn´t have a valid Stock");
            }

            if (this.Category_id == 0)
            {
                notification.addError("The Product doesn´t have a valid Category");
            }

            return notification;
        }
    }
}
