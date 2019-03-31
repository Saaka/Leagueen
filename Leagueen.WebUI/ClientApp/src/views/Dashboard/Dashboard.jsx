import React from 'react';

const Dashboard = (props) => {

  const competitions = [
    "Premier League",
    "Primera Division",
    "Serie A",
    "Bundesliga",
    "Ligue 1",
    "UEFA Champions League",
    "FIFA World Cup",
    "UEFA European Championship",
    "Championship",
    "Eredivisie",
    "Primeira Liga"
  ];

  function renderCompetitions() {
    return competitions.map((c, key) => {
      return <li key={key}>{c}</li>
    });
  };

  return (
    <div className="jumbotron">
      <h4 className="display-4">Welcome to <em>Leagueen</em> homepage!</h4>
      <p className="lead">Check football scores, predict match result and compete with your friends.</p>
      <p>Currently supporting {competitions.length} competitions</p>
      <ul>
        {renderCompetitions()}
      </ul>
      <p className="lead">Football data provided by the <strong><a href="https://www.football-data.org/">Football-Data.org</a></strong> API.</p>
    </div>
  );
};

export { Dashboard };
