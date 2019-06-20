using Leagueen.Application.Competitions.Commands;
using Leagueen.Application.Matches.Commands;
using Leagueen.Domain.Constants;
using Leagueen.Domain.Enums;
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
        [HttpPost("updateSeason/{competitionCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateSeason(CompetitionType competitionCode)
        {
            await Mediator.Send(new UpdateCompetitionCurrentSeasonCommand { CompetitionType = competitionCode });

            return Ok();
        }

        [HttpPost("updateAllMatches/{competitionCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateAllSeasonMatches(CompetitionType competitionCode)
        {
            await Mediator.Send(new UpdateAllSeasonMatchesCommand { CompetitionType = competitionCode });

            return Ok();
        }

        [HttpPost("updateCurrentMatches")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateCurrentMatches()
        {
            await Mediator.Send(new UpdateCurrentMatchesCommand { ProviderType = DataProviderType.FootballData });

            return Ok();
        }
    }
}
