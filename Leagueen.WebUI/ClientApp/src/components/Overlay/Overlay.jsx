import React from 'react';
import "./Overlay.scss";

function Overlay(props) {

    function showOverlay() {
        if(props.showOverlay)
            return "overlay active";
        return "overlay hidden";
    }

    return (
        <div className={showOverlay()} onClick={props.toggleSidebar} />
    );
};

export { Overlay };