using InkaPharmacy.Api.Common.Application;
using InkaPharmacy.Api.Common.Application.Enum;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InkaPharmacy.API.Common.Controllers
{
    public class BaseController : ControllerBase
    {
        public Logger logger, logger1, logger2;

        public BaseController()
        {
            logger = new ConsoleLogger(LogLevel.All);
            logger1 = logger.SetNext(new EmailLogger(LogLevel.FunctionalMessage | LogLevel.FunctionalError));
            logger2 = logger1.SetNext(new FileLogger(LogLevel.Warning | LogLevel.Error));
        }

        [NonAction]
        public void ThrowErrors(Notification notification)
        {
            if (notification.HasErrors()) {
                throw new ArgumentException(notification.ErrorMessage());
            }
        }
    }
}
