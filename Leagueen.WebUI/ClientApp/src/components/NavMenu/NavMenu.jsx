import React from "react";
import { Link } from "react-router-dom";
import { Icon } from "components/Icon/Icon";
import "./NavMenu.scss";

function NavMenu(props) {

  return (
    <nav className="navbar border-bottom box-shadow mb-3 ng-white navbar-light" role="navigation">
      <div className="container-fluid">
        <div className="navbar-header navbar-left pull-left">
          <button className="mr-2 navbar-toggler" type="button" onClick={props.toggleSidebar}>
            <Icon icon="align-left" />
          </button>
          <span className="navbar-brand">Leagueen</span>
        </div>
        <ul className="navbar-nav flex-row float-right">
          <li className="nav-item">
            <span className="navbar-text">Welcome, <strong>Guest</strong>!</span>
          </li>
          <li className="nav-item">
            <Link className="nav-link" to="/home"> Login</Link>
          </li>
        </ul>
      </div>
    </nav>
  );
};

export { NavMenu };
