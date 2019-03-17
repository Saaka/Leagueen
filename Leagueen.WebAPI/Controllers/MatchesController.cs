using Leagueen.Application.Matches.Queries;
using Leagueen.Application.Matches.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Leagueen.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MatchesController : BaseController
    {
        [HttpGet("getTodaysMatches")]
        public async Task<GetTodaysMatchesQueryResult> GetTodaysMatches()
        {
            return await Mediator.Send(new GetTodaysMatchesQuery());
        }
    }
}
