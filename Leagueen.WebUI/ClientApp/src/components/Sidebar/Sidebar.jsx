import React from "react";
import { Link } from 'react-router-dom';
import "./Sidebar.scss";

function Sidebar(props) {

    return (
        <div className="bg-light" id="sidebar-wrapper">
            <div className="sidebar-heading">Leagueen</div>
            <div className="list-group list-group-flush">
                <Link className="list-group-item list-group-item-action bg-light nav-link" to="/home" >Home</Link>
                <Link className="list-group-item list-group-item-action bg-light nav-link" to="/counter" >Counter</Link>
            </div>
        </div>
    );
};

export { Sidebar };