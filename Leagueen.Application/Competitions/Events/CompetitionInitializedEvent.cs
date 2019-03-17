using Leagueen.Domain.Enums;
using MediatR;

namespace Leagueen.Application.Competitions.Events
{
    public class CompetitionInitializedEvent : INotification
    {
        public CompetitionType CompetitionType { get; set; }
    }
}
