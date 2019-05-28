import React, { useState, useEffect } from "react";
import { UserGroupsService } from "Services";
import { Loader, Icon } from "components/common";

export function CreateGroup(props) {

    const groupsService = new UserGroupsService();
    const [group, setGroup] = useState({
        name: "",
        description: ""
    });
    const [isLoading, toggleLoading] = useState(true);
    const [isSubmitted, setSubmitted] = useState(false);

    const validations = {
        nameMaxLength: 64,
        nameMinLength: 6
    };

    useEffect(() => loadData(), []);

    function loadData() {
        toggleLoading(false);
    }

    function submitGroup(ev) {
        ev.preventDefault();
        setSubmitted(true);
        var formIsValid = ev.target.checkValidity();
        if (formIsValid) {
            //Create game
        }
    }

    const getFormClass = () => isSubmitted ? "was-validated" : "";

    function handleChange(ev) {
        const { name, value } = ev.target;
        setGroup(groupState => ({ ...groupState, [name]: value }))
    }

    function renderGroup() {
        return (
            <div>
                <h5 className="display-5 group-title">Create user group <Icon icon="users"/></h5>
                <form name="createGroupForm" onSubmit={(ev) => submitGroup(ev)} noValidate className={getFormClass()}>
                    <div className="form-group">
                        <label htmlFor="groupName">Name</label>
                        <input type="text"
                            className="form-control"
                            id="groupName"
                            name="name"
                            maxLength={validations.nameMaxLength}
                            minLength={validations.nameMinLength}
                            value={group.name}
                            onChange={handleChange}
                            required />
                        <div className="invalid-feedback">Group name is required (valid name length is between {validations.nameMinLength} and {validations.nameMaxLength} characters)</div>
                    </div>
                    <div className="form-group">
                        <label htmlFor="groupDesc">Description</label>
                        <textarea className="form-control"
                            id="groupDesc"
                            name="description"
                            rows="5"
                            value={group.description}
                            onChange={handleChange}>
                        </textarea>
                    </div>
                    <button className="btn btn-accent" type="submit">Save</button>
                </form>
            </div>
        );
    }

    function renderLoader() {
        return (<Loader isLoading={isLoading}></Loader>);
    }

    return isLoading === true ? renderLoader() : renderGroup();
};