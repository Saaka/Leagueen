import "./App.scss";
import React, { useState } from "react";
import { Switch, Route, Redirect } from "react-router";
import { NavMenu } from "components/NavMenu/NavMenu";
import { Sidebar } from "components/Sidebar/Sidebar";
import { Footer } from "components/Footer/Footer";
import { Overlay } from "components/Overlay/Overlay";
import appRoutes from "routes/app";

function App(props) {
  const [showSidebar, setShowSidebar] = useState(false);
  const [wrapperClasses, setWrapperClasses] = useState("d-flex");

  function toggleSidebar() {
    setShowSidebar(!showSidebar);
    if (showSidebar)
      setWrapperClasses("active");
    else
      setWrapperClasses("");
  }

  function renderApp(props) {
    return (
      <div>
        <div className={wrapperClasses} id="wrapper">
          <Sidebar {...props} showSidebar={showSidebar} toggleSidebar={toggleSidebar} />
          <div id="content">
            <NavMenu toggleSidebar={toggleSidebar} />
            <div className="container">
              <Switch>
                {appRoutes.map((prop, key) => {
                  if (prop.redirect)
                    return <Redirect from={prop.path} to={prop.to} key={key} />
                  else
                    return <Route path={prop.path} component={prop.component} name={prop.name} key={key} />
                })}
              </Switch>
            </div>
            {/* <Footer /> */}
          </div>
        </div>
        <Overlay showOverlay={showSidebar} toggleSidebar={toggleSidebar} />
      </div>
    );
  };

  return (
    <div>
      <Route exact path="/" render={(props) => <Redirect to="/app" from={props.path} />} />
      <Route path="/login" render={() => <div>Login</div>} />
      <Route path="/app" render={(props) => renderApp(props)} />
    </div>
  );
}

export { App };