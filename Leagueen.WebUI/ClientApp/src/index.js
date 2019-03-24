import "bootstrap";
import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter, Route } from "react-router-dom";
import { App } from "./layouts/App/App";
import "./assets/vendor/font-awesome";
require("dotenv").config();

const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const rootElement = document.getElementById("root");

ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
    <Route component={App} />
  </BrowserRouter>,
  rootElement);
