import React, { Component } from "react";
import Axios from "axios";
import { Button } from "components/exports";

export class Counter extends Component {
    state = {
        currentCount: 0,
        incrementValue: 1
    };
    _axios = null;
    get axios() {
        if (!this._axios)
            this._axios = this.createAxios();

        return this._axios;
    }

    createAxios = () => {
        return Axios.create({
            baseURL: process.env.REACT_APP_API_URL
        });
    };

    componentDidMount = () => {
        this.axios
            .get('/values/2')
            .then(resp => this.setState({
                incrementValue: resp.data
            }))
            .catch(err => console.log(err));
    };

    incrementCounter = () => {
        this.setState({
            currentCount: this.state.currentCount + this.state.incrementValue
        });
    }

    render() {
        return (
            <div>
                <h1>Counter</h1>

                <p>This is a simple example of a React component.</p>

                <p>Increment value: <strong>{this.state.incrementValue}</strong></p>
                <p>Current count: <strong>{this.state.currentCount}</strong></p>

                <button className="btn btn-info btn-fill" onClick={this.incrementCounter}>Increment</button>
                <button className="btn btn-info btn-fill" disabled>Decrement</button>
            </div>
        );
    }
}
