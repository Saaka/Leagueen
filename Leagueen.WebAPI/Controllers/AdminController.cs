using Leagueen.Application.Competitions.Commands;
using Leagueen.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Leagueen.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = UserRoles.Admin)]
    public class AdminController : BaseController
    {
        [HttpPost("UpdateCompetitionSeasons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateCompetitionSeasons()
        {
            await Mediator.Send(new UpdateCompetitionsSeasonsCommand());

            return Ok();
        }

        [HttpPost("UpdateSeasonTeams/{competitionCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateSeasonTeams(string competitionCode)
        {
            await Mediator.Send(new UpdateCompetitionTeamsInCurrentSeasonCommand { CompetitionCode = competitionCode });

            return Ok();
        }
    }
}
