using EnterprisePatterns.Api.Common.Application;

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

        public virtual Notification validateFindByDocumentNumber(string DocumentNumber)
        {
            Notification notification = new Notification();

            if (string.IsNullOrEmpty(DocumentNumber))
            {
                notification.addError("The Document Number is null");
            }

            return notification;
        }


    }
}
