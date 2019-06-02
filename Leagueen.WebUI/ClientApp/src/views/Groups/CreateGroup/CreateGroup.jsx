import React, { useState, useEffect } from "react";
import { UserGroupsService, CompetitionsService } from "Services";
import { Loader, Icon, Select } from "components/common";
import { RouteNames } from "routes/names";
import "./CreateGroup.scss";

export function CreateGroup(props) {

    const groupsService = new UserGroupsService();
    const competitionsService = new CompetitionsService();
    const [group, setGroup] = useState({
        name: "",
        description: ""
    });
    const [settings, setSettings] = useState({
        pointsForExactScore: 5,
        pointsForResult: 3,
        type: 1,
        visibility: 2,
        resultResolveMode: 1,
        competitionId: null,
        seasonId: null
    });
    const [isLoading, toggleLoading] = useState(true);
    const [isSubmitted, setSubmitted] = useState(false);
    const [seasons, setSeasons] = useState([]);
    const [showResultInfo, setShowResultInfo] = useState(false);

    const validations = {
        descriptionMaxLength: 1024,
        nameMaxLength: 64,
        nameMinLength: 6,
        exactMin: 1,
        exactMax: 20,
        resMin: 1,
        resMax: 20
    };

    useEffect(() => loadData(), []);

    function loadData() {
        competitionsService
            .getSeasonsDictionary()
            .then(dict => {
                if (!!dict.length) {
                    setSeasons(dict);
                    updateSelectedSeason(dict[0].id, dict);
                }
                toggleLoading(false);
            });
    }

    function submitGroup(ev) {
        ev.preventDefault();
        setSubmitted(true);
        var formIsValid = ev.target.checkValidity();
        if (formIsValid) {
            let request = { ...group, ...settings };
            groupsService
                .saveGroup(request)
                .then(resp => {
                    redirectToList();
                });
        }
    }

    const getFormClass = () => isSubmitted ? "was-validated" : "";

    function handleGroupChange(ev) {
        const { name, value } = ev.target;
        setGroup(groupState => ({ ...groupState, [name]: value }));
    }

    function handleSettingsChange(ev) {
        const { name, value } = ev.target;
        setSettings(s => ({ ...s, [name]: value }));
    }

    function handleSeasonChange(ev) {
        const { value } = ev.target;
        updateSelectedSeason(Number(value), seasons);
    }

    function updateSelectedSeason(value, dict) {
        if (!!!value || dict.length === 0)
            return;

        const competitionId = dict.filter((v, i) => v.id === value)[0].competitionId;
        setSettings(s => ({ ...s, seasonId: value, competitionId: competitionId }));
    }

    const cancel = () => redirectToList();

    function redirectToList() {
        props.history.push(RouteNames.UserGroups);
    }

    function renderInfo() {
        return showResultInfo ? (
            <div className="card mt-2">
                <div className="card-body">
                    <Icon icon="info-circle" /> Final result is calculated based on regular time plus extra. Penalties count as draw.
                </div>
            </div>
        ) : null;
    }

    function renderGroup() {
        return (
            <div className="col-md-4 offset-md-4">
                <h5 className="display-5 group-title">Create user group <Icon icon="users" /></h5>
                <form name="createGroupForm" onSubmit={(ev) => submitGroup(ev)} noValidate className={getFormClass()}>
                    <div>
                        <label htmlFor="groupName">Name</label>
                        <input type="text"
                            className="form-control"
                            id="groupName"
                            name="name"
                            maxLength={validations.nameMaxLength}
                            minLength={validations.nameMinLength}
                            value={group.name}
                            onChange={handleGroupChange}
                            required />
                        <div className="invalid-feedback">Group name is required (valid name length is between {validations.nameMinLength} and {validations.nameMaxLength} characters)</div>
                    </div>
                    <div>
                        <label htmlFor="groupDesc">Description</label>
                        <input className="form-control"
                            id="groupDesc"
                            name="description"
                            maxLength={validations.descriptionMaxLength}
                            value={group.description}
                            onChange={handleGroupChange} />
                        <div className="invalid-feedback">Description can't be longer than {validations.descriptionMaxLength} characters</div>
                    </div>
                    <div>
                        <label htmlFor="season">Season</label>
                        <Select className="form-control"
                            id="season"
                            name="seasonId"
                            values={seasons}
                            onChange={handleSeasonChange}
                            required>
                        </Select>
                        <div className="invalid-feedback">Season is required</div>
                    </div>
                    <div>
                        <label htmlFor="pointsForExactScore">Points for exact score</label>
                        <input type="number"
                            className="form-control"
                            id="pointsForExactScore"
                            name="pointsForExactScore"
                            min={validations.exactMin}
                            max={validations.exactMax}
                            value={settings.pointsForExactScore}
                            onChange={handleSettingsChange}
                            required />
                        <div className="invalid-feedback">Value must be greater than {validations.exactMin} and less than {validations.exactMax}</div>
                    </div>
                    <div>
                        <label htmlFor="pointsForResult">Points for result <Icon
                            icon="info-circle"
                            className="info-click"
                            onClick={() => setShowResultInfo(!showResultInfo)}
                        />
                        </label>
                        <input type="number"
                            className="form-control"
                            id="pointsForResult"
                            name="pointsForResult"
                            min={validations.resMin}
                            max={settings.pointsForExactScore}
                            value={settings.pointsForResult}
                            onChange={handleSettingsChange}
                            required />
                        <div className="invalid-feedback">Value must be greater than {validations.resMin} and less or equal than "Points for exact score"</div>
                    </div>
                    {renderInfo()}
                    <br />
                    <button className="btn btn-accent mr-3" type="submit">Save</button>
                    <button className="btn btn-secondary" type="button" onClick={(ev) => cancel(ev)}>Cancel</button>
                </form>
            </div>
        );
    }

    function renderLoader() {
        return (<Loader isLoading={isLoading}></Loader>);
    }

    return isLoading === true ? renderLoader() : renderGroup();
};