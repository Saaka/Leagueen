import React from 'react';
import { AuthService, ConfigService } from 'Services';
import { Icon } from 'components/Icon/Icon';

const LoginWithFacebook = (props) => {
    const configService = new ConfigService();
    const authService = new AuthService();

    function onLogin(response) {

    }

    function onLoginFail(response) {
        props.onError(response);
    }

    return (
        <>
            <button className="btn btn-theme login-button"
                onClick={props.onClick}>
                <Icon icon="facebook-f"></Icon> Sign in with Facebook
            </button>
        </>
    );
};

export { LoginWithFacebook as FacebookLogin };