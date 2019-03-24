import React from "react";
import { Icon } from "components/Icon/Icon";
import "./Logout.scss";

function Logout(props) {

    return (
        <div className="container h-100 d-flex justify-content-center">
            <div className="auto-center">
                <h1 className="logout-spinner"><Icon icon="spinner" spin /></h1>
            </div>
        </div>
    );
};

export { Logout };