using System;
using System.Collections.Generic;
using System.Linq;

namespace InkaPharmacy.Api.Common.Application
{
    public class Notification
    {
        private List<Error> errors = new List<Error>();
        
        public void AddError(String message)
        {
            AddError(message, null);
        }

        public void AddError(String message, Exception e)
        {
            errors.Add(new Error(message, e));
        }

        public string ErrorMessage()
        {
            return string.Join(", ", errors.Select(t => t.message));
        }

        public bool HasErrors()
        {
            return errors.Any();
        }
    }
}
