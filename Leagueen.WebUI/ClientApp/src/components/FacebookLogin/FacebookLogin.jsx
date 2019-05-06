import React from "react";
import { AuthService, ConfigService } from "Services";
import FacebookLogin from "react-facebook-login/dist/facebook-login-render-props";
import { Icon } from "components/Icon/Icon";

const LoginWithFacebook = (props) => {
    const configService = new ConfigService();
    const authService = new AuthService();

    function onLogin(response) {
        props.showLoader();
        authService
            .loginWithFacebook(response.accessToken)
            .then(props.onLoggedIn)
            .catch(onLoginFail);
    }

    function onLoginFail(response) {
        props.onError(response);
    }

    return (
        <FacebookLogin
            appId={configService.FacebookAppId}
            callback={onLogin}
            fields="name,email,picture"
            render={props => (
                <button className="btn btn-theme login-button"
                    onClick={props.onClick}>
                    <Icon icon="facebook-f"></Icon> Sign in with Facebook
                    </button>
            )}
        />
    );
};

export { LoginWithFacebook as FacebookLogin };