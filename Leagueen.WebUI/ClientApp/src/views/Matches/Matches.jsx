import React, { useEffect, useState } from "react";
import { CompetitionMatches } from "components/matches";
import { MatchesService } from "Services";
import { Loader, DateSelect } from "components/common";
import "./Matches.scss";

function Matches(props) {
    const matchesService = new MatchesService();
    const [competitions, setCompetitions] = useState([]);
    const [date, setDate] = useState(new Date());
    const [isLoading, toggleLoading] = useState(true);

    useEffect(() => loadMatches(date), []);

    function loadMatches(matchesDate) {
        toggleLoading(true);
        matchesService
            .getMatchesByDate(matchesDate)
            .then(resp => {
                setMatchesData(resp.data);
                toggleLoading(false);
            });
    }

    function setMatchesData(data) {
        setCompetitions(data.competitions);
    };

    function showCompetitions() {
        return competitions.map((c, key) => {
            return <CompetitionMatches competition={c} key={key} />
        });
    };

    function onDateChange(newDate) {
        setDate(newDate);
        loadMatches(newDate);
    }

    function renderMatches() {
        return (
            <div>
                <h5 className="display-5 matches-title mr-2">Matches </h5><DateSelect date={date} onChange={onDateChange} />
                
                {showCompetitions()}
            </div>
        );
    }

    function renderLoader() {
        return (<Loader isLoading={isLoading}></Loader>);
    }

    return isLoading === true ? renderLoader() : renderMatches();
};

export { Matches };

