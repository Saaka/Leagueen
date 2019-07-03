import React, { useState, useEffect } from "react";
import { Icon } from "components/common";
import { RouteNames } from "routes/names";
import "./Group.scss";

export function Group(props) {

    const [id] = useState(props.match.params.id);
    useEffect(() => load(), []);

    function load() {
    };

    function close() {
        props.history.push(RouteNames.UserGroups);
    }

    function renderView() {
        return (
            <div>
                <h5 className="display-5 group-title">Group: {id} <Icon icon="users" /></h5>
                <div>
                    <button className="btn btn-secondary" type="button" onClick={(ev) => close(ev)}>Close</button>
                </div>
            </div>
        )
    }

    return renderView();
};