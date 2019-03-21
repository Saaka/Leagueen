import "./App.scss";
import React from "react";
import { Switch, Route, Redirect } from "react-router";
import { NavMenu } from "components/NavMenu/NavMenu";
import { Sidebar } from "components/Sidebar/Sidebar";
import appRoutes from "routes/app";

function App(props) {

  return (
    <div className="d-flex" id="wrapper">
      <Sidebar {...props} />
      <div id="page-content-wrapper">
        <NavMenu />
        <div className="container-fluid">
          <Switch>
            {appRoutes.map((prop, key) => {
              if (prop.redirect)
                return <Redirect from={prop.path} to={prop.to} key={key} />
              else
                return <Route path={prop.path} component={prop.component} name={prop.name} key={key} />
            })}
          </Switch>
        </div>
      </div>
    </div>
  );
}

export default App;