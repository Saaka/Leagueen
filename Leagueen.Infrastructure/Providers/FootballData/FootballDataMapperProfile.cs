using AutoMapper;
using Leagueen.Application.DataProviders.Competitions;
using Leagueen.Application.DataProviders.Matches;
using Leagueen.Infrastructure.Providers.FootballData.ProviderModels;

namespace Leagueen.Infrastructure.Providers.FootballData
{
    public class FootballDataMapperProfile : Profile
    {
        public FootballDataMapperProfile()
        {
            CreateMap<CompetitionsListModel, CompetitionsListDto>();
            CreateMap<CompetitionModel, CompetitionDto>();
            CreateMap<CompetitionSeasonModel, CompetitionSeasonDto>()
                .ForMember(d => d.SeasonWinnerId, cfg => cfg.MapFrom(m => FootballDataMapperHelper.MapOptionalTeamId(m.Winner)));
            
            CreateMap<CompetitionTeamsListModel, CompetitionTeamsListDto>()
                .ForMember(x=> x.TeamsCount, c => c.MapFrom(m => m.Count));
            CreateMap<CompetitionInfoModel, CompetitionInfoDto>();
            CreateMap<TeamModel, TeamDto>()
                .ForMember(d => d.ClubColors, c => c.MapFrom(m => FootballDataMapperHelper.ConvertClubColors(m.ClubColors)));

            CreateMap<MatchListModel, MatchListDto>();
            CreateMap<MatchModel, MatchDto>()
                .ForMember(d => d.Status, c => c.MapFrom(m => FootballDataMapperHelper.ConvertStatus(m.Status)))
                .ForMember(d => d.Stage, c => c.MapFrom(m => FootballDataMapperHelper.ConvertStage(m.Stage)))
                .ForMember(d => d.Group, c => c.MapFrom(m => FootballDataMapperHelper.ConvertGroup(m.Group)))
                .ForMember(d => d.SeasonId, c=> c.MapFrom(m => m.Season.Id))
                .ForMember(d => d.CompetitionId, c=> c.MapFrom(m => m.Competition.Id))
                .ForMember(d => d.HomeTeamId, c=> c.MapFrom(m => m.HomeTeam.Id))
                .ForMember(d => d.AwayTeamId, c => c.MapFrom(m => m.AwayTeam.Id));
            CreateMap<MatchScoreModel, MatchScoreDto>()
                .ForMember(d => d.Winner, c => c.MapFrom(m => FootballDataMapperHelper.ConvertResult(m.Winner)))
                .ForMember(d => d.Duration, c => c.MapFrom(m => FootballDataMapperHelper.ConvertDuration(m.Duration)));
            CreateMap<ScoreValueDto, MatchScoreValueModel>();
        }
    }
}
