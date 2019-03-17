﻿using Leagueen.Application.Matches.Queries;
using Leagueen.Application.Matches.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Leagueen.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MatchesController : BaseController
    {
        [HttpGet("today")]
        public async Task<GetMatchesQueryResult> GetTodaysMatches()
        {
            return await Mediator.Send(new GetTodaysMatchesQuery());
        }

        [HttpGet("{date}")]
        public async Task<GetMatchesQueryResult> GetTodaysMatches(DateTime date)
        {
            return await Mediator.Send(new GetMatchesByDateQuery { Date = date });
        }
    }
}
