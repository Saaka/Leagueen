import React from "react";
import { Route, Redirect } from "react-router-dom";
import { App, Login } from "layouts/exports";

function IndexRoutes() {

    return (
        <div>
            <Route exact path="/" render={(props) => <Redirect to="/app" from={props.path} />} />
            <Route path="/login" component={Login} />
            <Route path="/app" component={App} />
        </div>
    );
};

export { IndexRoutes };