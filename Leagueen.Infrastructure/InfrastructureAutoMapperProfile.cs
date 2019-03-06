using AutoMapper;
using Leagueen.Application.Security;
using Leagueen.Infrastructure.Security.Google;

namespace Leagueen.Infrastructure
{
    public class InfrastructureAutoMapperProfile : Profile
    {
        public InfrastructureAutoMapperProfile()
        {
            CreateMap<GoogleTokenInfo, TokenInfo>()
                .ForMember(x => x.ExternalUserId, c => c.MapFrom(t => t.GoogleUserId));
        }
    }
}
