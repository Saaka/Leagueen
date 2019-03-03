using Leagueen.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Leagueen.WebAPI.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());


        protected ActionResult GetResult<TBaseRes, TReturned>(TBaseRes @base, Func<TReturned> result)
            where TBaseRes : RequestResultBase
            where TReturned : class, new()
        {
            if (@base.IsSuccessful)
            {
                return Ok(result());
            }
            else
            {
                return BadRequest(new { @base.Error });
            }
        }

        protected ActionResult GetResult<TRes>(TRes @base)
            where TRes : RequestResultBase
        {
            if (@base.IsSuccessful)
            {
                return Ok(@base);
            }
            else
            {
                return BadRequest(new { @base.Error });
            }
        }
    }
}
