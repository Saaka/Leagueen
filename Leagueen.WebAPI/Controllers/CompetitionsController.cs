using Leagueen.Application.Competitions.Models;
using Leagueen.Application.Competitions.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Leagueen.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CompetitionsController : BaseController
    {
        [Authorize]
        [HttpGet("seasonsDictionary")]
        public async Task<ActionResult<GetSeasonsDictionaryQueryResult>> GetCurrentSeasonsDictionary()
        {
            var result = await Mediator.Send(new GetSeasonsDictionaryQuery());
            return Ok(result);
        }
    }
}
