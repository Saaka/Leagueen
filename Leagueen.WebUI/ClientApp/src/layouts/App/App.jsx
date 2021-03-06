import "./App.scss";
import React, { useReducer } from "react";
import { Switch, Route, Redirect } from "react-router";
import { NavMenu, Sidebar, Overlay } from "components/common";
import { AuthRoute, AdminRoute } from "components/navigation";
import { sidebarReducer } from "reducers/sidebarReducer";
import { OPEN_SIDEBAR, CLOSE_SIDEBAR } from "reducers/actionTypes";
import appRoutes from "routes/app";

function App(props) {
  const [sidebar, dispatchSidebar] = useReducer(sidebarReducer, { show: false });

  function toggleSidebar() {
    if (sidebar.show)
      dispatchSidebar({ type: CLOSE_SIDEBAR });
    if (!sidebar.show)
      dispatchSidebar({ type: OPEN_SIDEBAR });
  };

  return (
    <div>
      <div className="d-flex" id="wrapper">
        <Sidebar {...props} showSidebar={sidebar.show} toggleSidebar={toggleSidebar} user={props.user} />
        <div id="content">
          <NavMenu toggleSidebar={toggleSidebar} user={props.user} />
          <div className="container">
            <Switch>
              {appRoutes.map((prop, key) => {
                if (prop.redirect)
                  return <Redirect from={prop.path} to={prop.to} key={key} />
                else if (prop.useAuth)
                  if (prop.requireAdmin)
                    return <AdminRoute path={prop.path} component={prop.component} name={prop.name} key={key} user={props.user} />
                  else
                    return <AuthRoute path={prop.path} component={prop.component} name={prop.name} key={key} user={props.user} />
                else
                  return <Route path={prop.path} component={prop.component} name={prop.name} key={key} />;
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