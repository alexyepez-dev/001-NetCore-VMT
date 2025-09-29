using System.Net;
using _001_VMT.Shared.Helpers.Message;
using _001_VMT.Shared.Helpers.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _001_VMT.Shared.ExceptionFilter;

public class ExceptionManager : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var result = (int)HttpStatusCode.InternalServerError;

        context.ExceptionHandled = true;

        var exceptionInternalError = SharedMessage.InternalErrorGeneral;
        var error = ApiResult.InternalError<string>(exceptionInternalError, context);

        context.Result = new ObjectResult(error)
        {
            StatusCode = result
        };
    }
}