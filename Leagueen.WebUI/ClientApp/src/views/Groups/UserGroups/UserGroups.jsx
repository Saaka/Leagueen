import React, { useState, useEffect } from "react";
import { UserGroupsService } from "Services";
import { Loader, Icon } from "components/common";
import { RouteNames } from "routes/names";
import "./UserGroups.scss";

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

    function showGroup(id) {
        props.history.push(RouteNames.Group_Id + id);
    }

    function renderList() {
        return (
            <table className="table table-hover">
                <thead>
                    <tr>
                        <th className="table-header">Name</th>
                        <th className="table-header table-header-small"></th>
                        <th className="table-header table-header-small"></th>
                    </tr>
                </thead>
                <tbody>
                    {groups.map((g, k) =>
                        <tr key={k} onClick={(ev) => showGroup(g.groupGuid)} className="table-row">
                            <td>{g.name}</td>
                            <td>{g.isAdmin ? <span>Admin <Icon icon="star" /></span> : ""}</td>
                            <td>{g.isPrivate ? <span> Private <Icon icon="lock" /></span> : ""}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
        // return groups.map((g, key) => {
        //     return <div>{g.name}</div>
        // });
    }

    function createGroup() {
        props.history.push(RouteNames.CreateGroup);
    }

    function renderGroups() {
        return (
            <div>
                <h5 className="display-5 groups-title">User groups
                    <button className="btn btn-sm btn-accent ml-2" onClick={() => createGroup()}>Create group <Icon icon="plus" /></button>
                </h5>
                {renderList()}
            </div>
        );
    }

    function renderLoader() {
        return (<Loader isLoading={isLoading}></Loader>);
    }

    return isLoading === true ? renderLoader() : renderGroups();
};