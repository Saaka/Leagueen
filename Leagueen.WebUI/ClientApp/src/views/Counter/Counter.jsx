import React, { useState, useEffect } from "react";
import { HttpService, ToastService } from "Services";
import "./Counter.scss";

export function Counter(props) {
    const [currentValue, setCurrentValue] = useState(0);
    const [incrementValue, setIncrementValue] = useState(1);

    useEffect(() => {
        var http = new HttpService();
        http.get('values/2')
            .then(resp => {
                setIncrementValue(resp.data);
                ToastService.success(`Increment value loaded: ${incrementValue}`);
            })
            .catch(err => console.log(err));
    }, []);

    function incrementCounter() {
        setCurrentValue(currentValue + incrementValue);
        ToastService.error(`Current counter value: ${currentValue}`);
    }

    return (
        <div className="counter-content">
            <div className="jumbotron popup">
                <h1 className="display-4">Counter</h1>

                <p className="lead">This is a simple example of a React component.</p>

                <p>Increment value: <span className="badge badge-accent">{incrementValue}</span></p>
                <p>Current count: <span className="badge badge-accent">{currentValue}</span></p>

                <button className="btn btn-accent" onClick={incrementCounter}>Increment</button>
                
                <hr />
                {props.user && props.user.isLoggedIn ? <p>Current user: {props.user.displayName}</p> : <p>Not logged in</p> }
                
            </div>
        </div>
    );
};
