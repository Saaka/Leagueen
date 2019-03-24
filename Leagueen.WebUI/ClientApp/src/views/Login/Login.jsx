import React, { useEffect } from "react";
import queryString from "query-string";
import { GoogleLogin } from "components/GoogleLogin/GoogleLogin";
import "./Login.scss";

function Login(props) {

    useEffect(() => {
        if (props.user.isLoggedIn)
            redirectToMainPage();
    });
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
        console.log(err);
    };

    return (
        <div className="container h-100 d-flex justify-content-center logout-content login-content">
            <div className="auto-center">
                <div className="row justify-content-center bottom-offset">
                    <div className="col-md-9 col-lg-6">
                        <h1 className="text-center">Leagueen</h1>
                        <br />
                        <div className="row justify-content-center">
                            <GoogleLogin onLoggedIn={onLoggedIn} onError={onError} showLoader={() => props.toggleLoader(true)}></GoogleLogin>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export { Login };