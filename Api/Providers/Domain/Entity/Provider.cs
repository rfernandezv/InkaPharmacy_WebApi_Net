using InkaPharmacy.Api.Common.Application;

namespace InkaPharmacy.Api.Providers.Domain.Entity
{
    public class Provider
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string DocumentNumber { get; set; }
        public virtual string Address { get; set; }
        public virtual string Telephone { get; set; }
        public virtual int Status { get; set; }

        public Provider()
        {
        }

        public virtual Notification validateForSave()
        {
            Notification notification = new Notification();

            if (this == null)
            {
                notification.AddError("Provider is null");
            }

            return notification;
        }

        public virtual Notification ValidateFindByDocumentNumber(string DocumentNumber)
        {
            Notification notification = new Notification();

            if (string.IsNullOrEmpty(DocumentNumber))
            {
                notification.AddError("The Document Number is null");
            }

            return notification;
        }

        public virtual Notification ValidateFindByName(string Name)
        {
            Notification notification = new Notification();

            if (string.IsNullOrEmpty(Name))
            {
                notification.AddError("The Provider name is null");
            }

            return notification;
        }

    }
}
