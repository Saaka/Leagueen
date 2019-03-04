using Leagueen.Application.Exceptions;
using Leagueen.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
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
                HandleValidationException(exception as ValidationException, context);
            }
            else if (exception is RepositoryException)
            {
                HandleValidationException(exception as RepositoryException, context);
            }
            else
            {

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

        private void HandleValidationException(ValidationException validationException, ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new JsonResult(new
            {
                Error = validationException.Message,
                Errors = validationException.Errors.Select(ToCamelCase).ToList(),
                ErrorDetails = validationException.Failures,
            });
        }

        private void HandleValidationException(RepositoryException repositoryException, ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new JsonResult(new
            {
                Error = repositoryException.Message,
                Errors = repositoryException.Errors
            });
        }

        private string ToCamelCase(string input)
        {
            if (input.Length <= 1)
                return input;

            return $"{input.ToLowerInvariant()[0]}{input.Substring(1)}";
        }
    }
}
