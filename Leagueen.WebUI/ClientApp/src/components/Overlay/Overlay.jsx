import React from 'react';

function Overlay(props) {

    function showOverlay() {
        if(props.showOverlay)
            return "overlay active";
        return "overlay";
    }

    return (
        <div className={showOverlay()} />
    );
};

export { Overlay };