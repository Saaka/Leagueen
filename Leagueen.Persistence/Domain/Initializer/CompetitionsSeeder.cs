using Leagueen.Common;
using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace Leagueen.Persistence.Domain.Initializer
{
    public class CompetitionsSeeder
    {
        private readonly AppDbContext context;
        private readonly IGuid guid;

        public CompetitionsSeeder(
            AppDbContext context,
            IGuid guid)
        {
            this.context = context;
            this.guid = guid;
        }

        public async Task ExecuteAsync()
        {
            if (!context.Competitions.Any())
            {
                await InitBaseCompetitions();
            }
        }

        private async Task InitBaseCompetitions()
        {
            var dataProvider = new DataProvider(guid.GetGuid(), DataProviderType.FootballData, "football-data.org");

            var competitions = new[]
            {
                new Competition(guid.GetGuid(), CompetitionType.PL, CompetitionModel.League, "Premier League", CompetitionType.PL.ToString(), "2021", false, dataProvider),
                new Competition(guid.GetGuid(), CompetitionType.PD, CompetitionModel.League, "Primera Division", CompetitionType.PD.ToString(), "2014", false, dataProvider),
                new Competition(guid.GetGuid(), CompetitionType.SA, CompetitionModel.League, "Serie A", CompetitionType.SA.ToString(), "2019", false, dataProvider),
                new Competition(guid.GetGuid(), CompetitionType.BL1, CompetitionModel.League, "Bundesliga", CompetitionType.BL1.ToString(), "2002", false, dataProvider),
                new Competition(guid.GetGuid(), CompetitionType.FL1, CompetitionModel.League, "Ligue 1", CompetitionType.FL1.ToString(), "2015", false, dataProvider),
                new Competition(guid.GetGuid(), CompetitionType.CL, CompetitionModel.Cup, "UEFA Champions League", CompetitionType.CL.ToString(), "2001", false, dataProvider),
                new Competition(guid.GetGuid(), CompetitionType.WC, CompetitionModel.Cup, "FIFA World Cup", CompetitionType.WC.ToString(), "2000", false, dataProvider),
                new Competition(guid.GetGuid(), CompetitionType.EC, CompetitionModel.Cup,"European Championship", CompetitionType.EC.ToString(), "2018", false, dataProvider),
                new Competition(guid.GetGuid(), CompetitionType.ELC, CompetitionModel.League, "Championship", CompetitionType.ELC.ToString(), "2016", false, dataProvider),
                new Competition(guid.GetGuid(), CompetitionType.DED, CompetitionModel.League, "Eredivisie", CompetitionType.DED.ToString(), "2003", false, dataProvider),
                new Competition(guid.GetGuid(), CompetitionType.PPL, CompetitionModel.League, "Primeira Liga", CompetitionType.PPL.ToString(), "2017", false, dataProvider),
                new Competition(guid.GetGuid(), CompetitionType.BSA, CompetitionModel.League,  "Série A", CompetitionType.BSA.ToString(), "2013", false, dataProvider),
            };

            context.Competitions.AddRange(competitions);
            await context.SaveChangesAsync();
        }
    }
}
