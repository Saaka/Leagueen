import React from "react";
import { RedirectLink } from "components/RedirectLink/RedirectLink";
import "./Sidebar.scss";

import appRoutes from "routes/app";

function Sidebar(props) {

    function setActivity() {
        if (props.showSidebar)
            return "active";
        return "";
    };

    function linkClass(prop) {
        if(prop.path === props.location.pathname)
            return "btn btn-primary active"

        return "btn btn-primary";
    };

    function renderLink(prop, key) {

        return (
            <li key={key}>
                <RedirectLink className={linkClass(prop)} name={prop.name} to={prop.path}></RedirectLink>
            </li>
        );
    };

    return (
        <div className={setActivity()} id="sidebar">
            <button className="btn btn-primary-dark" id="dismiss" onClick={props.toggleSidebar}>
                <i className="fas fa-arrow-left"></i>
            </button>
            <div className="sidebar-header"><h3>Leagueen</h3></div>

            <ul className="list-unstyled components justify-content-center">
                {appRoutes.map((prop, key) => {
                    if (prop.redirect) return null;

                    return renderLink(prop, key);
                })}
            </ul>
        </div>
    );
};

export { Sidebar };