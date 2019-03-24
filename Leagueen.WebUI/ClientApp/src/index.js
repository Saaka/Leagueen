import "bootstrap";
import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import { IndexRoutes } from "routes/IndexRoutes";
import "./assets/vendor/font-awesome";
require("dotenv").config();

const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const rootElement = document.getElementById("root");

ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
    <IndexRoutes />
  </BrowserRouter>,
  rootElement);
