import React, { useState, useEffect } from "react";
import { Route, Redirect } from "react-router-dom";
import { App } from "layouts/exports";
import { Logout, Login } from "views/exports";
import { AuthService } from "Services";
import { Loader } from "components/Loader/Loader";
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
            .catch(removeUser)
            .finally(hideLoader);
    };

    function removeUser() {
        setUser({
            isLoggedIn: false
        });
        return authService.logout()
    };

    function updateUser(user) {
        hideLoader();
        setUser({
            ...user,
            isLoggedIn: true
        });
    };

    const onLogin = (user) => updateUser(user);

    const onLogout = () => removeUser();

    const hideLoader = () => setIsLoading(false);

    function renderApp() {
        return (
            <span>
                <Route exact path="/" render={(props) => <Redirect to="/app" from={props.path} {...props} user={user} />} />
                <Route path="/login" render={(props) => <Login {...props} onLogin={onLogin} onLogout={onLogout} user={user} toggleLoader={setIsLoading} />} />
                <Route path="/logout" render={(props) => <Logout {...props} onLogout={onLogout} />} />
                <Route path="/app" render={(props) => <App {...props} user={user} />} />
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