import React, { useState, useEffect } from "react";
import { Icon } from "components/common";
import { RouteNames } from "routes/names";
import "./FriendsList.scss";

export function FriendsList(props) {

    useEffect(() => load(), []);

    function load() {
    };

    function addFriend() {

    };

    function renderView() {
        return (
            <div>
                <h5 className="display-5 friends-list-title">Friends list
                    <button className="btn btn-sm btn-accent ml-2" onClick={() => addFriend()}>Add friend <Icon icon="plus" /></button>
                </h5>
            </div>
        )
    }

    return renderView();
};