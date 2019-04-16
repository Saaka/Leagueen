import React from 'react';

const Unauthorized = (props) => {

    return (
        <div className="jumbotron">
          <h4 className="display-5">Unauthorized</h4>
          <p className="lead">Sorry, You don't have required permissions to view this page!</p>
        </div>
    );
};

export { Unauthorized };