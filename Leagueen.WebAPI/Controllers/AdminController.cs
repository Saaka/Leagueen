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

        [HttpPost("initializeSeason/{competitionCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> InitializeSeason(string competitionCode)
        {
            await Mediator.Send(new InitializeCompetitionCurrentSeasonCommand { CompetitionCode = competitionCode });

            return Ok();
        }

        [HttpPost("updateAllMatches/{competitionCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateAllSeasonMatches(string competitionCode)
        {
            await Mediator.Send(new UpdateAllSeasonMatchesCommand { CompetitionCode = competitionCode });

            return Ok();
        }

        [HttpPost("updateCurrentMatches")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateCurrentMatches()
        {
            await Mediator.Send(new UpdateCurrentMatchesCommand { ProviderType = Domain.Enums.DataProviderType.FootballData });

            return Ok();
        }
    }
}
