using Leagueen.Application.Competitions.Models;
using Leagueen.Application.Competitions.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions.Queries.GetSeasonsDictionary
{
    public class GetCompetitionsDictionaryQueryHandler : IRequestHandler<GetSeasonsDictionaryQuery, GetSeasonsDictionaryQueryResult>
    {
        private readonly ICompetitionsRepository competitionsRepository;

        public GetCompetitionsDictionaryQueryHandler(
            ICompetitionsRepository competitionsRepository)
        {
            this.competitionsRepository = competitionsRepository;
        }

        public async Task<GetSeasonsDictionaryQueryResult> Handle(GetSeasonsDictionaryQuery request, CancellationToken cancellationToken)
        {
            var currentSeasons = await competitionsRepository.GetCurrentSeasonsDictionary();

            return new GetSeasonsDictionaryQueryResult
            {
                Seasons = currentSeasons.ToList()
            };
        }
    }
}
