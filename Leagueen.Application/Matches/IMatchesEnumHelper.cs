using Leagueen.Domain.Enums;

namespace Leagueen.Application.Matches
{
    public interface IMatchesEnumHelper
    {
        MatchStatus ConvertStatusCode(string status);
        MatchStage ConvertStage(string stage);
    }
}
