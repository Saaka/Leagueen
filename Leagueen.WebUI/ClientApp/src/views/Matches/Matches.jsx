import React, { useEffect, useState } from "react";
import { CompetitionMatches } from "components/matches";
import { MatchesService } from "Services";
import { Loader, DateSelect, Icon } from "components/common";
import "./Matches.scss";

function Matches(props) {
    const matchesService = new MatchesService();
    const [competitions, setCompetitions] = useState([]);
    const [date, setDate] = useState(new Date());
    const [openCalendar, toggleOpenCalendar] = useState(false);
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
        toggleOpenCalendar(false);
        setDate(newDate);
        loadMatches(newDate);
    }

    function renderSelectDate() {
        return openCalendar ? <DateSelect date={date} onChange={onDateChange} close={() => toggleOpenCalendar(false)} withPortal inline /> : null;
    }

    function renderMatches() {
        return (
            <div>
                <h5 className="display-5 matches-title">Matches - {date.toLocaleDateString()}
                    <button className="btn btn-sm btn-accent ml-2" onClick={ () => toggleOpenCalendar(true) }>Select date <Icon icon="calendar-alt" /></button>
                </h5>
                {renderSelectDate()}
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

