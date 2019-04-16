import React, { useState, useEffect } from "react";
import { Route, Redirect } from "react-router-dom";
import { App } from "layouts/exports";
import { Logout, Login } from "views/exports";
import { AuthService, ToastComponent, ToastService } from "Services";
import { Loader } from "components/common";
import { RouteNames } from "routes/names";
import "./Index.scss";

function Index(props) {
    const authService = new AuthService();
    const [isLoading, setIsLoading] = useState(true);
    const [user, setUser] = useState({ isLoggedIn: false });

    useEffect(() => {
        if (authService.isLoggedIn())
            loadUserData();
        else
            hideLoader();
    }, []);

    function loadUserData() {
        authService
            .getUser()
            .then(updateUser)
            .catch(onError)
            .finally(hideLoader);
    };

    function onError(err) {
        ToastService.info(err);
        removeUser();
    }

    function removeUser() {
        setUser({
            isLoggedIn: false
        });
        return authService.logout()
    };

    function updateUser(user) {
        setUser({
            ...user,
            isLoggedIn: true
        });
    };

    const onLogin = (user) => {
        hideLoader();
        updateUser(user);
    };

    const onLogout = () => removeUser();

    const hideLoader = () => setIsLoading(false);

    function renderApp() {
        return (
            <span>
                <Route exact path={RouteNames.Root} render={(props) => <Redirect to={RouteNames.App} from={props.path} {...props} user={user} />} />
                <Route path={RouteNames.Login} render={(props) => <Login {...props} onLogin={onLogin} onLogout={onLogout} user={user} toggleLoader={setIsLoading} />} />
                <Route path={RouteNames.Logout} render={(props) => <Logout {...props} onLogout={onLogout} />} />
                <Route path={RouteNames.App} render={(props) => <App {...props} user={user} />} />
                <ToastComponent />
            </span>
        );
    };

    function renderLoader() {
        return (
            <div>
                <Loader isLoading={isLoading}></Loader>
            </div>
        );
    };

    return isLoading === true ? renderLoader() : renderApp();
};

export { Index };