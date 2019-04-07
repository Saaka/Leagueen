import "bootstrap";
import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import { Index } from "layouts/exports";
import "./assets/vendor/font-awesome";
import configureInternationalization from "./i18n";
require("dotenv").config();

const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const rootElement = document.getElementById("root");

configureInternationalization();
ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
    <Index />
  </BrowserRouter>,
  rootElement);
