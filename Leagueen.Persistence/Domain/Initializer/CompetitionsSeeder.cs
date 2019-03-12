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
            var competitions = new[]
            {
                new Competition(CompetitionType.PL, CompetitionModel.League, "Premier League", CompetitionType.PL.ToString(), 2021, true),
                new Competition(CompetitionType.PD, CompetitionModel.League, "Primera Division", CompetitionType.PD.ToString(), 2014, true),
                new Competition(CompetitionType.SA, CompetitionModel.League, "Serie A", CompetitionType.SA.ToString(), 2019, true),
                new Competition(CompetitionType.BL1, CompetitionModel.League, "Bundesliga", CompetitionType.BL1.ToString(), 2002, true),
                new Competition(CompetitionType.FL1, CompetitionModel.League, "Ligue 1", CompetitionType.FL1.ToString(), 2015, true),
                new Competition(CompetitionType.CL, CompetitionModel.Cup, "UEFA Champions League", CompetitionType.CL.ToString(), 2001, true),
                new Competition(CompetitionType.WC, CompetitionModel.Cup, "FIFA World Cup", CompetitionType.WC.ToString(), 2000, true),
                new Competition(CompetitionType.EC, CompetitionModel.Cup,"European Championship", CompetitionType.EC.ToString(), 2018, true),
                new Competition(CompetitionType.ELC, CompetitionModel.League, "Championship", CompetitionType.ELC.ToString(), 2016, true),
                new Competition(CompetitionType.DED, CompetitionModel.League, "Eredivisie", CompetitionType.DED.ToString(), 2003, true),
                new Competition(CompetitionType.PPL, CompetitionModel.League, "Primeira Liga", CompetitionType.PPL.ToString(), 2017, true),
                new Competition(CompetitionType.BSA, CompetitionModel.League,  "Série A", CompetitionType.BSA.ToString(), 2013, false),
            };

            context.Competitions.AddRange(competitions);
            await context.SaveChangesAsync();
        }
    }
}
