using Leagueen.Application.Requests;
using Leagueen.Common;
using Leagueen.WebAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Leagueen.WebAPI.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        private IUserContextDataProvider _userContextDataProvider;
        private IGuid _guid;

        protected IMediator Mediator
            => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
        protected IUserContextDataProvider UserContextDataProvider
            => _userContextDataProvider ?? (_userContextDataProvider = HttpContext.RequestServices.GetService<IUserContextDataProvider>());
        protected IGuid GuidProvider
            => _guid ?? (_guid = HttpContext.RequestServices.GetService<IGuid>());

        protected async Task<int> GetUserId() => await UserContextDataProvider.GetUser(HttpContext);

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

        protected ActionResult GetRequestResult<TRes>(TRes @base)
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
