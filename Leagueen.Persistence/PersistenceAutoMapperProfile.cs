using AutoMapper;
using Leagueen.Application.Users.Models;
using Leagueen.Domain.Entities;

namespace Leagueen.Persistence
{
    public class PersistenceAutoMapperProfile : Profile
    {
        public PersistenceAutoMapperProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
