import React, { useState, useEffect } from "react";
import { UserGroupsService } from "Services";
import { Loader } from "components/common";

export function UserGroups(props) {

    const groupsService = new UserGroupsService();
    const [groups, setGroups] = useState([]);
    const [isLoading, toggleLoading] = useState(true);

    useEffect(() => loadUserGroups(), []);

    function loadUserGroups() {
        toggleLoading(true);
        groupsService
            .getUserGroups()
            .then(resp => {
                setGroups(resp.data.userGroups);
                toggleLoading(false);
            });
    }

    function renderList() {
        return groups.map((g, key) => {
            return <div>{g.name}</div>
        });
    }

    function renderGroups() {
        return (
            <div>
                <h5 className="display-5 groups-title">User groups</h5>
                {renderList()}
            </div>
        );
    }

    function renderLoader() {
        return (<Loader isLoading={isLoading}></Loader>);
    }

    return isLoading === true ? renderLoader() : renderGroups();
};