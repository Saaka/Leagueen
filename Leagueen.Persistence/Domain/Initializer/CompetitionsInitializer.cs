using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace Leagueen.Persistence.Domain.Initializer
{
    public interface ICompetitionsSeeder
    {
        Task ExecuteAsync();
    }

    public class CompetitionsSeeder : ICompetitionsSeeder
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
                new Competition(CompetitionType.PL, "Premier League", CompetitionType.PL.ToString(), 2021),
                new Competition(CompetitionType.PD, "Primera Division", CompetitionType.PD.ToString(), 2014),
                new Competition(CompetitionType.SA, "Serie A", CompetitionType.SA.ToString(), 2019),
                new Competition(CompetitionType.BL1, "Bundesliga", CompetitionType.BL1.ToString(), 2002),
                new Competition(CompetitionType.FL1, "Ligue 1", CompetitionType.FL1.ToString(), 2015),
                new Competition(CompetitionType.CL, "UEFA Champions League", CompetitionType.CL.ToString(), 2001),
                new Competition(CompetitionType.WC, "FIFA World Cup", CompetitionType.WC.ToString(), 2000),
                new Competition(CompetitionType.EC, "European Championship", CompetitionType.EC.ToString(), 2018),
                new Competition(CompetitionType.ELC, "Championship", CompetitionType.ELC.ToString(), 2016),
                new Competition(CompetitionType.DED, "Eredivisie", CompetitionType.DED.ToString(), 2003),
                new Competition(CompetitionType.PPL, "Primeira Liga", CompetitionType.PPL.ToString(), 2017),
                new Competition(CompetitionType.BSA, "Série A", CompetitionType.BSA.ToString(), 2013),
            };

            context.Competitions.AddRange(competitions);
            await context.SaveChangesAsync();
        }
    }
}
