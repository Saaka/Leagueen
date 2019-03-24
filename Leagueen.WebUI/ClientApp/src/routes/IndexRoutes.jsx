import React from "react";
import { Route, Redirect } from "react-router-dom";
import { App } from "layouts/exports";
import { Logout, Login } from "views/exports";

function IndexRoutes() {

    function onLogin(user) {

    };

    function onLogout() {

    };

    return (
        <span>
            <Route exact path="/" render={(props) => <Redirect to="/app" from={props.path} />} />
            <Route path="/login" render={(props) => <Login {...props} onLogin={onLogin} onLogout={onLogout} />} />
            <Route path="/logout" render={(props) => <Logout {...props} onLogout={onLogout} />} />
            <Route path="/app" component={App} />
        </span>
    );
};

export { IndexRoutes };