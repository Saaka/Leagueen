﻿using Leagueen.Application.Users.Commands;
using Leagueen.WebAPI.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Leagueen.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(CreateUserViewModel request)
        {
            await Mediator.Send(new CreateUserCommand(
                userGuid: request.UserGuid,
                email: request.Email,
                displayName: request.DisplayName,
                imageUrl: request.ImageUrl
                ));

            return Ok();
        }
    }
}