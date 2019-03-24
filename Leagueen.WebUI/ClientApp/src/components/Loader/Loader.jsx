import React from 'react';
import './Loader.scss';

function Loader(props) {

    return (
        <span className="bottom-offset">
            {props.isLoading ? <div className="loading">Loading&#8230;</div> : <div></div>}
        </span>
    );
};

export { Loader };