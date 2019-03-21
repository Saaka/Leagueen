import React from "react";
import { Switch, Route, Redirect } from "react-router";
import { NavMenu, Sidebar } from "components/exports";
import appRoutes from "routes/app";

function App(props) {

  return (
    <div className="wrapper">
      <Sidebar {...props} />
      <div id="main-panel" className="main-panel">
        <NavMenu />
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
  );
}

export default App;