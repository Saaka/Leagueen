import React, { useEffect } from "react";
import { Icon } from "components/Icon/Icon";
import "./Logout.scss";

function Logout(props) {

    useEffect(() => {
        
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