import "./App.scss";
import React, { useState } from "react";
import { Switch, Route, Redirect } from "react-router";
import { NavMenu } from "components/NavMenu/NavMenu";
import { Sidebar } from "components/Sidebar/Sidebar";
import { Footer } from "components/Footer/Footer";
import { Overlay } from "components/Overlay/Overlay";
import { useAuth } from "Services";
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
  };

  function renderAuthComponent(props, component) {
    var AuthComponent = useAuth(component);
    return (
      <AuthComponent {...props} user={props.user} />
    );
  };

  return (
    <div>
      <div className={wrapperClasses} id="wrapper">
        <Sidebar {...props} showSidebar={showSidebar} toggleSidebar={toggleSidebar} />
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
}

export { App };