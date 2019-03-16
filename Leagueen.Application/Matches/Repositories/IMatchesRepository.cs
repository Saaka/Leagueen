using Leagueen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leagueen.Application.Matches.Repositories
{
    public interface IMatchesRepository
    {
        Task<IEnumerable<Match>> GetAllMatchesByDate(DateTime date);
        Task<bool> AreMatchesInPlay(DateTime dateTime);
    }
}
