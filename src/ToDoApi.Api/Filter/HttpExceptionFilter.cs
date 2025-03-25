using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ToDoApi.ToDoApi.Application.Attribute;

namespace ToDoApi.ToDoApi.Api.Filter;

public class HttpExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        var statusCode = HttpStatusCode.InternalServerError;
        if (exception.GetType().GetCustomAttributes(typeof(ExceptionHttpStatusCode), true).FirstOrDefault() is
            ExceptionHttpStatusCode attr)
        {
            statusCode = attr.HttpStatusCode;
        }

        context.Result = new ObjectResult(new { error = exception.Message })
        {
            StatusCode = (int)statusCode
        };
        context.ExceptionHandled = true;
    }
}