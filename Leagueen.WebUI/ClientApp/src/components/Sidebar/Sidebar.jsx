import React from "react";
import { NavLink } from "react-router-dom";

import appRoutes from "routes/app";

function Sidebar(props) {

    function activeRoute(path) {
        return props.location.pathname.indexOf(path) > -1 ? "active" : "";
    }

    return (
        <div id="sidebar"
            className="sidebar">
            <div className="sidebar-wrapper">
                <ul className="nav">
                    {appRoutes.map((prop, key) => {
                        if (prop.redirect)
                            return null;
                        return (
                            <li className={activeRoute(prop.path)} key={key}>
                                <NavLink
                                    to={prop.path}
                                    className="nav-link"
                                    activeClassName="active">
                                    <p>{prop.name}</p>
                                </NavLink>
                            </li>
                        );
                    })}
                </ul>
            </div>
        </div>
    );
};

export { Sidebar };