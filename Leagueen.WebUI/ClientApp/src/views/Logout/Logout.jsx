import React, { useEffect } from "react";
import { Icon } from "components/Icon/Icon";
import { AuthService } from 'Services';
import "./Logout.scss";

function Logout(props) {
    const authService = new AuthService();

    useEffect(() => {
        props.onLogout();
        authService.logout();
        props.history.replace('/');
    });

    return (
        <div className="h-100 d-flex justify-content-center logout-content">
            <div className="auto-center">
                <div className="bottom-offset">
                    <h1>Logging out</h1>
                    <h1><Icon icon="spinner" spin /></h1>
                </div>
            </div>
        </div>
    );
};

export { Logout };