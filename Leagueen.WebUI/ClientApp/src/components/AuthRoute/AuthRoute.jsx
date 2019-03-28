import React from "react";
import { Route, Redirect } from "react-router-dom";

function AuthRoute({
    component: Component,
    user,
    ...data
}) {
    return (
        <Route {...data}
            render={props => {
                if(user && user.isLoggedIn)
                    return <Component {...props} user={user} />
                else return (
                    <Redirect to={{
                        pathname: "/login",
                        search: `?redirect=${props.location.pathname}`,
                        state : {
                            from: props.location
                        }
                    }} />
                );
            }} />
    );
};

export { AuthRoute };