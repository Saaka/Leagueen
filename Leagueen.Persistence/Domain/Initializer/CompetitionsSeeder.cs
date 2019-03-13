using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace Leagueen.Persistence.Domain.Initializer
{
    public class CompetitionsSeeder
    {
        private readonly AppDbContext context;

        public CompetitionsSeeder(
            AppDbContext context)
        {
            this.context = context;
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
            var dataProvider = new DataProvider(DataProviderType.FootballData, "football-data.org");

            var competitions = new[]
            {
                new Competition(CompetitionType.PL, CompetitionModel.League, "Premier League", CompetitionType.PL.ToString(), 2021, true, dataProvider),
                new Competition(CompetitionType.PD, CompetitionModel.League, "Primera Division", CompetitionType.PD.ToString(), 2014, true, dataProvider),
                new Competition(CompetitionType.SA, CompetitionModel.League, "Serie A", CompetitionType.SA.ToString(), 2019, true, dataProvider),
                new Competition(CompetitionType.BL1, CompetitionModel.League, "Bundesliga", CompetitionType.BL1.ToString(), 2002, true, dataProvider),
                new Competition(CompetitionType.FL1, CompetitionModel.League, "Ligue 1", CompetitionType.FL1.ToString(), 2015, true, dataProvider),
                new Competition(CompetitionType.CL, CompetitionModel.Cup, "UEFA Champions League", CompetitionType.CL.ToString(), 2001, true, dataProvider),
                new Competition(CompetitionType.WC, CompetitionModel.Cup, "FIFA World Cup", CompetitionType.WC.ToString(), 2000, true, dataProvider),
                new Competition(CompetitionType.EC, CompetitionModel.Cup,"European Championship", CompetitionType.EC.ToString(), 2018, true, dataProvider),
                new Competition(CompetitionType.ELC, CompetitionModel.League, "Championship", CompetitionType.ELC.ToString(), 2016, true, dataProvider),
                new Competition(CompetitionType.DED, CompetitionModel.League, "Eredivisie", CompetitionType.DED.ToString(), 2003, true, dataProvider),
                new Competition(CompetitionType.PPL, CompetitionModel.League, "Primeira Liga", CompetitionType.PPL.ToString(), 2017, true, dataProvider),
                new Competition(CompetitionType.BSA, CompetitionModel.League,  "Série A", CompetitionType.BSA.ToString(), 2013, false, dataProvider),
            };

            context.Competitions.AddRange(competitions);
            await context.SaveChangesAsync();
        }
    }
}
