using Leagueen.Application.Competitions.Commands;
using Leagueen.Application.Matches.Commands;
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
        [HttpPost("updateCompetitionSeasons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateCompetitionSeasons()
        {
            await Mediator.Send(new UpdateCompetitionsSeasonsCommand());

            return Ok();
        }

        [HttpPost("updateSeasonTeams/{competitionCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateSeasonTeams(string competitionCode)
        {
            await Mediator.Send(new UpdateCompetitionTeamsInCurrentSeasonCommand { CompetitionCode = competitionCode });

            return Ok();
        }

        [HttpPost("updateCompetitionMatches/{competitionCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateSeasonMatches(string competitionCode)
        {
            await Mediator.Send(new UpdateSeasonMatchesCommand { CompetitionCode = competitionCode });

            return Ok();
        }        
    }
}
