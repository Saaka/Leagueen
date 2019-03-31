import React from "react";
import { Constants } from "Services";
import "./CompetitionMatches.scss";

function CompetitionMatches(props) {

    function getMatchTime(date) {
        return new Date(date + "+0000").toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
    };

    function getScore(match) {
        switch (match.status) {
            case Constants.MatchStatus.SCHEDULED:
                return (<span>vs</span>);
            case Constants.MatchStatus.IN_PLAY:
            case Constants.MatchStatus.PAUSED:
                return (<span className="badge badge-accent">{`${match.homeScore}:${match.awayScore}`}</span>);
            case Constants.MatchStatus.FINISHED:
                return (<span className="badge badge-secondary">{`${match.homeScore}:${match.awayScore}`}</span>);
            default:
                return (<span className="badge badge-info">{match.statusTest}</span>);
        }
    };

    function getRows(matches) {
        return matches.map((match, key) => {
            return (
                <tr key={key}>
                    <td className="info-col">{getMatchTime(match.date)}</td>
                    <td className="text-right team-col">{match.homeTeam}</td>
                    <td className="text-center score-col">{getScore(match)}</td>
                    <td className="text-left team-col">{match.awayTeam}</td>
                </tr>
            );
        });
    };

    return (
        <div>
            <h6 className="display-6">{props.competition.name}</h6>
            <table className="table table-borderless table-striped competition-scores-table">
                <thead>
                    <tr>
                        <th>Info</th>
                        <th>Home</th>
                        <th>Result</th>
                        <th>Away</th>
                    </tr>
                </thead>
                <tbody>
                    {getRows(props.competition.matches)}
                </tbody>
            </table>
        </div>
    );
};

export { CompetitionMatches };