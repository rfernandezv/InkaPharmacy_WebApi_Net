﻿using InkaPharmacy.Api.Common.Application;

namespace InkaPharmacy.Api.Customers
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

        public virtual Notification validateFindByDocumentNumber(string DocumentNumber)
        {
            Notification notification = new Notification();

            if (string.IsNullOrEmpty(DocumentNumber))
            {
                notification.addError("The Document Number is null");
            }

            return notification;
        }

        public virtual Notification ValidateForSave(string action = "")
        {
            Notification notification = new Notification();

            if (this == null)
            {
                notification.addError("The Customer is null");
            }

            if (action == "U")
            {
                if (this.Id == 0)
                {
                    notification.addError("The Customer doesn't have a valid Id");
                }
            }

            if (string.IsNullOrEmpty(this.Name))
            {
                notification.addError("The Customer doesn't have a valid Name");
            }

            return notification;
        }


    }
}
