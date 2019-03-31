import React, { useEffect, useState } from "react";
import { CompetitionMatches } from "components/matches";
import { MatchesService } from "Services";
import { Loader } from "components/common";

function Matches(props) {
    const matchesService = new MatchesService();
    const [competitions, setCompetitions] = useState([]);
    const [date, setDate] = useState(new Date());
    const [isLoading, toggleLoading] = useState(true);

    useEffect(() => {
        matchesService
            .getTodaysMatches()
            .then(resp => {
                setMatchesData(resp.data);
                toggleLoading(false);
            });
    }, []);

    function setMatchesData(data) {
        setCompetitions(data.competitions);
        setDate(new Date(data.date));
    };

    function showCompetitions() {
        return competitions.map((c, key) => {
            return <CompetitionMatches competition={c} key={key} />
        });
    };

    function renderMatches() {
        return (
            <div>
                <h5 className="display-5">Matches - { date.toLocaleDateString() }</h5>
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

