using Leagueen.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace Leagueen.WebAPI.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            if (exception is ValidationException)
            {
                var validationException = (ValidationException)context.Exception;
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(new
                {
                    Error = validationException.Message,
                    Errors = validationException.Errors,
                    ErrorDetails = validationException.Failures,
                });

                return;
            }

            var code = HttpStatusCode.InternalServerError;

            if (exception is ArgumentException)
                code = HttpStatusCode.BadRequest;

            if (exception is InvalidOperationException)
                code = HttpStatusCode.Forbidden;

            if (exception is UnauthorizedAccessException)
                code = HttpStatusCode.Unauthorized;


            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = new JsonResult(new
            {
                Error = context.Exception.Message
            });
        }
    }
}
