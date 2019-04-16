import React from "react";
import { Route, Redirect } from "react-router-dom";

function AdminRoute({
    component: Component,
    user,
    ...data
}) {
    return (
        <Route {...data}
            render={props => {
                if (user && user.isLoggedIn && user.isAdmin)
                    return <Component {...props} user={user} />
                else if (user && user.isLoggedIn && !user.isAdmin)
                    return (
                        <Redirect to={{
                            pathname: "/app/unauthorized",
                        }} />
                    );
                else return (
                    <Redirect to={{
                        pathname: "/login",
                        search: `?redirect=${props.location.pathname}`,
                        state: {
                            from: props.location
                        }
                    }} />
                );
            }} />
    );
};

export { AdminRoute };