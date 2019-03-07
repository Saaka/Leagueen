using AutoMapper;
using Leagueen.Application.Users.Models;
using Leagueen.Persistence.Identity.Entities;

namespace Leagueen.Persistence
{
    public class PersistenceAutoMapperProfile : Profile
    {
        public PersistenceAutoMapperProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
        }
    }
}
