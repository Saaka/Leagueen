import React from "react";
import { Link } from 'react-router-dom';
import "./Sidebar.scss";

function Sidebar(props) {

    function sidebarClasses() {
        if(props.showSidebar)
            return "active";
        return "";
    };

    return (
        <div className={sidebarClasses()} id="sidebar">
            <div id="dismiss" onClick={props.toggleSidebar}>
                <i className="fas fa-arrow-left"></i>
            </div>
            <div className="sidebar-header"><h3>Leagueen</h3></div>

            <ul className="list-unstyled components">
                <li className="active">
                    <Link className="list-group-item list-group-item-action bg-light nav-link" to="/home" >Home</Link>
                </li>
                <li className="active">
                <Link className="list-group-item list-group-item-action bg-light nav-link" to="/counter" >Counter</Link>
                </li>
            </ul>
        </div>
    );
};

export { Sidebar };