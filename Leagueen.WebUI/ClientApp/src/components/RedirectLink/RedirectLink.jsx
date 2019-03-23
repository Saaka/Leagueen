import React from "react";
import { withRouter } from "react-router-dom";

function RedirectLink(props) {

    function redirect() {
        if(!!props.onRedirect)
            props.onRedirect();
        props.history.push(props.to);
    };

    function render() {
        return <button className={props.className} type="button" role="navigation" onClick={redirect}>{props.name}</button>
    };

    return render();
};

const routerRedirectLink = withRouter(RedirectLink);
export { routerRedirectLink as RedirectLink };