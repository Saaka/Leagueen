import "./App.scss";
import React from "react";
import { Switch, Route, Redirect } from "react-router";
import { Layout } from "components/Layout";
import appRoutes from 'routes/app';

function App(props) {

  return (
    <Layout>
      <Switch>
        {appRoutes.map((prop, key) => {
          if (prop.redirect)
            return <Redirect from={prop.path} to={prop.to} key={key} />
          else
            return <Route path={prop.path} component={prop.component} name={prop.name} key={key} />
        })}
      </Switch>
    </Layout>
  );
}

export default App;