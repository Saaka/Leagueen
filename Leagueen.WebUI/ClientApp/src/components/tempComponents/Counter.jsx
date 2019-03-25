import React, { useState, useEffect } from "react";
import { HttpService } from "Services";
import "./Counter.scss";

export function Counter(props) {
    const [currentValue, setCurrentValue] = useState(0);
    const [incrementValue, setIncrementValue] = useState(1);

    useEffect(() => {
        var http = new HttpService();
        http.get('values/2')
            .then(resp => setIncrementValue(resp.data))
            .catch(err => console.log(err));
    }, []);

    function incrementCounter() {
        setCurrentValue(currentValue + incrementValue);
    }

    return (
        <div className="counter-content">
            <h1>Counter</h1>

            <p>This is a simple example of a React component.</p>

            <p>Increment value: <strong>{incrementValue}</strong></p>
            <p>Current count: <strong>{currentValue}</strong></p>

            <button className="btn btn-accent" onClick={incrementCounter}>Increment</button>
        </div>
    );
};
