import React, { useState, useEffect } from "react";
import { Icon } from "components/common";
import "./Group.scss";

export function Group(props) {

    const [id, setId] = useState(props.match.params.id);
    useEffect(() => load(), []);

    function load() {

    };

    function renderView() {
        return (
            <div>
                <h5 className="display-5 group-title">Group: {id} <Icon icon="users" /></h5>
            </div>
        )
    }

    return renderView();
};