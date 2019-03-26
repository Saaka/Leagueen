import React, { useEffect } from "react";
import { Icon } from "components/Icon/Icon";
import { AuthService } from 'Services';
import "./Logout.scss";

function Logout(props) {
    const authService = new AuthService();

    useEffect(() => {
        authService.logout();
        props.onLogout();
        props.history.replace('/');
    });

    return (
        <div className="h-100 d-flex justify-content-center logout-content">
            <div className="center-h">
                <h1>Logging out</h1>
                <h1><Icon icon="spinner" spin /></h1>
            </div>
        </div>
    );
};

export { Logout };