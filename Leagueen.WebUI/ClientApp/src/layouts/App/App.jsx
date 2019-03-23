import "./App.scss";
import React, { useState } from "react";
import { Switch, Route, Redirect } from "react-router";
import { NavMenu } from "components/NavMenu/NavMenu";
import { Sidebar } from "components/Sidebar/Sidebar";
import { Footer } from "components/Footer/Footer";
import appRoutes from "routes/app";

function App(props) {
  const [showSidebar, setShowSidebar] = useState(true);
  const [wrapperClasses, setWrapperClasses] = useState("d-flex");

  function toggleSidebar() {
    setShowSidebar(!showSidebar);
    if (showSidebar)
      setWrapperClasses("d-flex toggled");
    else
      setWrapperClasses("d-flex");
  }

  return (
    <div className={wrapperClasses} id="wrapper">
      <Sidebar {...props} showSidebar={showSidebar} />
      <div id="page-content-wrapper">
        <NavMenu toggleSidebar={toggleSidebar} />
        <div className="container-fluid" id="content">
          <Switch>
            {appRoutes.map((prop, key) => {
              if (prop.redirect)
                return <Redirect from={prop.path} to={prop.to} key={key} />
              else
                return <Route path={prop.path} component={prop.component} name={prop.name} key={key} />
            })}
          </Switch>
        </div>
        <Footer />
      </div>
    </div>
  );
}

export default App;