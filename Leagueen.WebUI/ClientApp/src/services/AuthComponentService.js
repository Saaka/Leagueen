import React, { useEffect } from 'react';

const useAuth = (AuthComponent) => {

    return function AuthWrapper(props){
        function goToLogin(useRedirect) {
            if (useRedirect) {
                var redirect = props.location.pathname;
                props.history.replace(`/login?redirect=${redirect}`);
            }
            else {
                props.history.replace('/');
            }
        };
        
        useEffect(() => {
            if (!props.user.isLoggedIn) {
                goToLogin(true);
            }
        }, []);

        return props.user.isLoggedIn ?
            <AuthComponent history={props.history} user={props.user} {...props} /> :
            null;
    };
}

export { useAuth };