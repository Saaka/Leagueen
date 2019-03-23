import React from "react";
import { RedirectLink } from "components/RedirectLink/RedirectLink";
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
                <li>
                    <RedirectLink className="btn btn-primary" name="Home" to="/home"></RedirectLink>
                </li>
                <li>
                    <RedirectLink name="Counter" to="/counter"></RedirectLink>
                </li>
            </ul>
        </div>
    );
};

export { Sidebar };