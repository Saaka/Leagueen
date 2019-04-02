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
                ToastService.success(`Increment value loaded: ${resp.data}`);
            })
            .catch(ToastService.error);
    }, []);

    function incrementCounter() {
        var value = currentValue + incrementValue;
        setCurrentValue(value);
        ToastService.info(`Current counter value: ${value}`);
    }

    function resetCounter() {
        setCurrentValue(0);
        ToastService.show("Counter set to 0");
    };

    return (
        <div className="counter-content">
            <div className="jumbotron popup">
                <h1 className="display-4">Counter</h1>

                <p className="lead">This is a simple example of a React component.</p>

                <p>Increment value: <span className="badge badge-accent">{incrementValue}</span></p>
                <p>Current count: <span className="badge badge-accent">{currentValue}</span></p>

                <button className="btn btn-accent" onClick={incrementCounter}>Increment</button>
                <button className="btn btn-accent-dark ml-2" onClick={resetCounter}>Reset</button>

                <hr />
                {props.user && props.user.isLoggedIn ? <p>Current user: {props.user.displayName}</p> : <p>Not logged in</p>}

            </div>
        </div>
    );
};
