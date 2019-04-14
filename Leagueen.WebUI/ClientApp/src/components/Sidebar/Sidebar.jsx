import React from "react";
import { RedirectLink } from "components/RedirectLink/RedirectLink";
import { Icon } from "components/Icon/Icon";
import appRoutes from "routes/app";
import "./Sidebar.scss";

function Sidebar(props) {

    function setActivity() {
        if (props.showSidebar)
            return "active";
        return "";
    };

    function linkClass(prop) {
        if (prop.path === props.location.pathname)
            return "btn btn-accent active"

        return "btn btn-accent";
    };

    function renderLink(prop, key) {
        return (
            <li key={key}>
                <RedirectLink className={linkClass(prop)} to={prop.path} onRedirect={props.toggleSidebar}>{prop.name}</RedirectLink>
            </li>
        );
    };

    function renderLoginButtons() {
        if (props.user.isLoggedIn)
            return <RedirectLink className="btn btn-accent" to="/logout" onRedirect={props.toggleSidebar}><Icon icon="sign-out-alt" /> Logout</RedirectLink>;
        else
            return <RedirectLink className="btn btn-accent" to="/login" onRedirect={props.toggleSidebar}><Icon icon="sign-in-alt" /> Login</RedirectLink>;
    };

    return (
        <div className={setActivity()} id="sidebar">
            <button className="btn btn-accent-dark" id="dismiss" onClick={props.toggleSidebar}>
                <Icon icon="arrow-left" />
            </button>
            <div className="sidebar-header"><h3>Leagueen</h3></div>

            <ul className="list-unstyled components justify-content-center">
                {appRoutes.map((prop, key) => {
                    if (prop.redirect) return null;

                    return renderLink(prop, key);
                })}
            </ul>
            <ul className="list-unstyled components justify-content-center">
                {renderLoginButtons()}
            </ul>
        </div >
    );
};
export { Sidebar };