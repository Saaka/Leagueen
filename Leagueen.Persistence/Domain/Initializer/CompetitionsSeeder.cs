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
                new Competition(CompetitionType.PL, CompetitionModelType.League, "Premier League", CompetitionType.PL.ToString(), 2021, false, dataProvider),
                new Competition(CompetitionType.PD, CompetitionModelType.League, "Primera Division", CompetitionType.PD.ToString(), 2014, false, dataProvider),
                new Competition(CompetitionType.SA, CompetitionModelType.League, "Serie A", CompetitionType.SA.ToString(), 2019, false, dataProvider),
                new Competition(CompetitionType.BL1, CompetitionModelType.League, "Bundesliga", CompetitionType.BL1.ToString(), 2002, false, dataProvider),
                new Competition(CompetitionType.FL1, CompetitionModelType.League, "Ligue 1", CompetitionType.FL1.ToString(), 2015, false, dataProvider),
                new Competition(CompetitionType.CL, CompetitionModelType.Cup, "UEFA Champions League", CompetitionType.CL.ToString(), 2001, false, dataProvider),
                new Competition(CompetitionType.WC, CompetitionModelType.Cup, "FIFA World Cup", CompetitionType.WC.ToString(), 2000, false, dataProvider),
                new Competition(CompetitionType.EC, CompetitionModelType.Cup,"European Championship", CompetitionType.EC.ToString(), 2018, false, dataProvider),
                new Competition(CompetitionType.ELC, CompetitionModelType.League, "Championship", CompetitionType.ELC.ToString(), 2016, false, dataProvider),
                new Competition(CompetitionType.DED, CompetitionModelType.League, "Eredivisie", CompetitionType.DED.ToString(), 2003, false, dataProvider),
                new Competition(CompetitionType.PPL, CompetitionModelType.League, "Primeira Liga", CompetitionType.PPL.ToString(), 2017, false, dataProvider),
                new Competition(CompetitionType.BSA, CompetitionModelType.League,  "Série A", CompetitionType.BSA.ToString(), 2013, false, dataProvider),
            };

            context.Competitions.AddRange(competitions);
            await context.SaveChangesAsync();
        }
    }
}
