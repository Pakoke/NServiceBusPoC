using NServiceBusPoC.UI.ViewEntities.Entities.Errors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace NServiceBusPoC.UI.ViewEntities.Errors
{
    //HTTP implements a wide variety of status codes, which are grouped into five categories.The five categories are distinguished by the code's first number, like so:

    //1XX Codes: Informational codes.Rarely used in modern web apps.
    //2XX Codes: Success codes. Tells the client that the request succeeded.
    //3XX Codes: Redirect codes. Tells the client that they may need to redirect to another location.
    //4XX Codes: Client Error codes.Tells the client that something was wrong with what it sent to the server.
    //5XX Codes: Server Error codes.Tells the client that something went wrong on the server's side, so that the client may attempt the request again, possibly at a later time.
    public class GeneralError : StatusCodeResult
    {
        public GeneralError(int statusCode = 0) : base(statusCode)
        {
            statusCode = CodeErrors.GeneralErrorCode;
        }

        public string ErrorMessage { get; set; }

        public DateTime TimeError => DateTime.UtcNow;

        public Exception ExceptionError { get; set; }

    }
}
