import "./App.scss";
import React, { useReducer } from "react";
import { Switch, Route, Redirect } from "react-router";
import { NavMenu } from "components/NavMenu/NavMenu";
import { Sidebar } from "components/Sidebar/Sidebar";
import { Overlay } from "components/Overlay/Overlay";
import { useAuth } from "Services";
import appRoutes from "routes/app";
import { sidebarReducer } from "reducers/sidebarReducer";
import { OPEN_SIDEBAR, CLOSE_SIDEBAR } from "reducers/actionTypes";

function App(props) {
  const [sidebar, dispatchSidebar] = useReducer(sidebarReducer, { show: false });

  function toggleSidebar() {
    if (sidebar.show)
      dispatchSidebar({ type: CLOSE_SIDEBAR });
    if (!sidebar.show)
      dispatchSidebar({ type: OPEN_SIDEBAR });
  };

  function renderAuthComponent(props, component) {
    var AuthComponent = useAuth(component);
    return (
      <AuthComponent {...props} user={props.user} />
    );
  };

  return (
    <div>
      <div className="d-flex" id="wrapper">
        <Sidebar {...props} showSidebar={sidebar.show} toggleSidebar={toggleSidebar} />
        <div id="content">
          <NavMenu toggleSidebar={toggleSidebar} user={props.user} />
          <div className="container">
            <Switch>
              {appRoutes.map((prop, key) => {
                if (prop.redirect)
                  return <Redirect from={prop.path} to={prop.to} key={key} />
                else if (prop.useAuth)
                  return <Route path={prop.path} name={prop.name} key={key} render={() => renderAuthComponent(props, prop.component)} />
                else
                  return <Route path={prop.path} component={prop.component} name={prop.name} key={key}/>;
              })}
            </Switch>
          </div>
        </div>
      </div>
      <Overlay showOverlay={sidebar.show} toggleSidebar={toggleSidebar} />
    </div>
  );
}

export { App };