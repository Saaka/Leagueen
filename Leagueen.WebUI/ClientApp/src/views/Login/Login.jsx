import React, { useEffect } from "react";
import queryString from "query-string";
import { GoogleLogin, FacebookLogin } from "components/common";
import { ToastService } from "Services";
import "./Login.scss";

function Login(props) {

    useEffect(() => {
        if (props.user.isLoggedIn)
            redirectToMainPage();
    }, []);
    function onLoggedIn(userData) {
        props.onLogin(userData);
        var searchValue = queryString.parse(props.location.search);
        if (searchValue && searchValue.redirect)
            redirectToPath(searchValue.redirect);
        else
            redirectToMainPage();
    };
    function redirectToMainPage() {
        props.history.replace("/");
    };
    function redirectToPath(path) {
        props.history.push(path);
    };
    function onError(err) {
        props.toggleLoader(false);
        ToastService.error(err);
        redirectToMainPage();
    };

    return (
        <div className="h-100 d-flex justify-content-center login-container">
            <div className="center-h">
                <div className="row justify-content-center">
                    <h1 className="text-center">Leagueen</h1>
                </div>
                <div className="row justify-content-center popup login-button-container">
                    <GoogleLogin onLoggedIn={onLoggedIn} onError={onError} showLoader={() => props.toggleLoader(true)} />
                </div>
                <div className="row justify-content-center popup login-button-container">
                    <FacebookLogin onLoggedIn={onLoggedIn} onError={onError} showLoader={() => props.toggleLoader(true)} />
                </div>
            </div>
        </div>
    );
};

export { Login };